using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using FluentBootstrap.Internals;

namespace FluentBootstrap
{  
    public abstract class Component
    {
        protected readonly static object ComponentStackKey = new object();
        protected readonly static object OutputStackKey = new object();

        private bool _started;
        private bool _finished;
        private readonly BootstrapConfig _config;
        private readonly List<Component> _children = new List<Component>();
        private readonly List<Component> _endChildren = new List<Component>();
        private readonly Component _parent;  // If this is set, all rendering calls get deferred to the parent - see .WithChild() extension
        private readonly Queue<ComponentOverride> _componentOverrides = new Queue<ComponentOverride>();

        public BootstrapConfig Config
        {
            get { return _config; }
        }

        // Implicit components are created by the library as wrappers, missing tags, etc.
        // The primary difference is that implicit components can be automatically cleaned up from the stack
        private readonly bool _implicit;

        public bool Implicit
        {
            get { return _implicit; }
        }

        private bool _render = true;

        public bool Render
        {
            set { _render = value; }
        }

        protected Component(BootstrapHelper helper)
        {
            _config = helper.GetConfig();
            _parent = helper.GetParent();
            _implicit = GetOutputStack().Count > 0;

            // Get any component override(s)
            ComponentOverride componentOverride = null;
            Type thisType = GetType();
            foreach (KeyValuePair<Type, Func<BootstrapConfig, Component, ComponentOverride>> match
                in Config.ComponentOverrides.Where(x => x.Key.IsAssignableFrom(thisType)))
            {
                ComponentOverride lastComponentOverride = componentOverride;
                componentOverride = match.Value(Config, this);
                componentOverride.BaseStartAction = OnStart;
                componentOverride.BaseFinishAction = OnFinish;
                if (lastComponentOverride != null)
                {
                    // If this is an override higher up the hierarchy, redirect the lower override to call this one
                    lastComponentOverride.BaseStartAction = componentOverride.OnStart;
                    lastComponentOverride.BaseFinishAction = componentOverride.OnFinish;
                }
                _componentOverrides.Enqueue(componentOverride);
            }
        }

        public TOverride GetOverride<TOverride>()
            where TOverride : ComponentOverride
        {
            return _componentOverrides.OfType<TOverride>().FirstOrDefault();
        }

        // Gets a temporary ComponentBuilder that can be used to access extension methods from overrides
        // Generally you'll pass in "this" for the component argument
        protected ComponentBuilder<BootstrapConfig, TComponent> GetBuilder<TComponent>(TComponent component)
            where TComponent : Component
        {
            return new ComponentBuilder<BootstrapConfig, TComponent>(Config, component);
        }

        // This gets a dummy BootstrapHelper that can be used to create new components with the same config (though untyped) as this one
        public BootstrapHelper<BootstrapConfig, CanCreate> GetHelper()
        {
            return new DummyBootstrapHelper(Config);
        }

        private class DummyBootstrapHelper : BootstrapHelper<BootstrapConfig, CanCreate>
        {
            public DummyBootstrapHelper(BootstrapConfig config)
                : base(config)
            {
            }
        }

        public void AddChild(Component child)
        {
            _children.Add(child);
        }

        public void AddChild(ComponentBuilder builder)
        {
            _children.Add(builder.GetComponent());
        }

        public void AddChildAtEnd(Component child)
        {
            _endChildren.Add(child);
        }

        public void AddChildAtEnd(ComponentBuilder builder)
        {
            _endChildren.Add(builder.GetComponent());
        }

        internal void Begin(TextWriter writer)
        {
            // If we have a parent, it needs to be started
            if (_parent != null)
            {
                _parent.Begin(writer);
            }

            Start(writer ?? Config.GetWriter());
        }

        internal void End(TextWriter writer)
        {
            Finish(writer ?? Config.GetWriter());

            // If we have a parent, it needs to be finished
            if (_parent != null)
            {
                _parent.End(writer);
            }
        }

        // This should only be used implicitly in a view and not from within this library (because of the way pending components are handled)
        // Instead, use Component.StartAndFinish() to write out the content of a component during Prepare, OnStart, or OnFinish
        public override string ToString()
        {
            // Write this component out as a string
            using (StringWriter writer = new StringWriter())
            {
                // If we have a parent, it needs to be started
                if (_parent != null)
                {
                    _parent.Begin(writer);
                }

                StartAndFinish(writer);

                // If we have a parent, it needs to be finished
                if (_parent != null)
                {
                    _parent.End(writer);
                }

                return writer.ToString();
            }

        }

        internal void Start(TextWriter writer)
        {
            // Only write content once
            if (_started)
            {
                return;
            }
            _started = true;

            // Stop now if not rendering
            if (!_render)
            {
                return;
            }

            // Note that this component is outputting
            GetOutputStack().Push(this);

            // Output the content
            if (_componentOverrides.Count > 0)
            {
                _componentOverrides.Peek().OnStart(writer);
            }
            else
            {
                OnStart(writer);
            }

            // Clear this component from the output stack
            if (GetOutputStack().Pop() != this)
            {
                throw new InvalidOperationException("Popped a different Bootstrap component from the output stack while starting (you should never see this).");
            }

            // Write any children
            WriteChildren(_children, writer);
        }

        internal void Finish(TextWriter writer)
        {
            // Only write content once
            if (_finished)
            {
                return;
            }
            _finished = true;

            // Stop now if not rendering
            if (!_render)
            {
                return;
            }

            // Write any end children
            WriteChildren(_endChildren, writer);

            // Get the stack
            Stack<Component> stack = GetComponentStack();

            // Peek components until we get to this one - the call to Finish() will pop them
            Component peek = null;
            while (stack.Count > 0 && (peek = stack.Peek()) != this && peek.Implicit)
            {
                peek.Finish(writer);
            }

            // Sanity check
            if (peek != this)
            {
                throw new InvalidOperationException("A Bootstrap component is finishing but is not at the top of the stack, " +
                    "which is usually an indication that a component has been disposed out of order " +
                    "or that more than one component was created in a single using statement.");
            }

            // Note that this component is outputting
            GetOutputStack().Push(this);

            // Output the content
            if (_componentOverrides.Count > 0)
            {
                _componentOverrides.Peek().OnFinish(writer);
            }
            else
            {
                OnFinish(writer);
            }

            // Clear this component from the output stack
            if (GetOutputStack().Pop() != this)
            {
                throw new InvalidOperationException("Popped a different Bootstrap component from the output stack while finishing (you should never see this).");
            }
        }

        // This is implicit by definition since it's only ever used inside another component to generate content for a child, etc.
        internal void StartAndFinish(TextWriter writer)
        {
            Start(writer);
            Finish(writer);
        }

        // This must be called from overloads as it adds the component to the stack
        // To suppress output, pass in SuppressOutputWriter
        protected virtual void OnStart(TextWriter writer)
        {
            Push();
        }

        // This must be called from overloads as it removes the component from the stack
        // To suppress output, pass in SuppressOutputWriter
        protected virtual void OnFinish(TextWriter writer)
        {
            // Get the stack
            Stack<Component> stack = GetComponentStack();

            // Pop the component from the stack
            if (stack.Count == 0)
            {
                throw new InvalidOperationException("Finishing a Bootstrap component with an empty stack (you should never see this).");
            }
            Component pop = stack.Pop();
            if (pop != this)
            {
                throw new InvalidOperationException("Popped a different Bootstrap component from the component stack (you should never see this).");
            }
        }

        private void WriteChildren(List<Component> children, TextWriter writer)
        {
            foreach (Component child in children)
            {
                child.StartAndFinish(writer);
            }
        }

        // The following code handles the stack of Bootstrap objects stored in the ViewContext

        private void Push()
        {
            GetComponentStack().Push(this);
        }

        // This pops up the stack if (and only if) it is assignable to the specified type
        // Use this to clear arbitrary implicitly added components from the stack (see how Tables.Row works)
        internal void Pop<TComponent>(TextWriter writer)
            where TComponent : Component
        {
            Stack<Component> stack = GetComponentStack();

            // Crawl the stack and queue the components in case an intermediate is not implicit
            Queue<Component> finish = new Queue<Component>();
            if (stack.Count > 0)
            {
                foreach (Component component in stack.Cast<Component>())
                {
                    if (component == this)
                    {
                        continue;
                    }
                    if (!component.Implicit)
                    {
                        break;
                    }
                    finish.Enqueue(component);
                    if (typeof(TComponent).IsAssignableFrom(component.GetType()))
                    {
                        // Found the type we were looking for, go ahead and finish it and the intermediates
                        while (finish.Count > 0)
                        {
                            finish.Dequeue().Finish(writer);
                        }
                        break;
                    }
                }
            }
        }

        // This pops up the stack if (and only if) the requested component and all intermediate components are implicit
        // Use this to clear specific implicitly added components from the stack (see how Forms.Input works)
        internal void Pop(Component pop, TextWriter writer)
        {
            if (pop == null || !pop.Implicit)
            {
                return;
            }
            Stack<Component> stack = GetComponentStack();

            // Crawl the stack and queue the components in case an intermediate is not implicit
            Queue<Component> finish = new Queue<Component>();
            if (stack.Count > 0)
            {
                foreach (Component component in stack.Cast<Component>())
                {
                    if (!component.Implicit)
                    {
                        break;
                    }
                    finish.Enqueue(component);
                    if (component == pop)
                    {
                        // Found the component we were looking for, so go ahead and finish it and the intermediates
                        while (finish.Count > 0)
                        {
                            finish.Dequeue().Finish(writer);
                        }
                        break;
                    }
                }
            }
        }

        // onlyParent indicates that just the parent component in the stack should be searched (instead of all the way up)
        protected TComponent GetComponent<TComponent>(bool onlyParent = false)
            where TComponent : Component
        {
            Stack<Component> stack = GetComponentStack();
            if (stack.Count == 0)
            {
                return null;
            }
            if (onlyParent)
            {
                // Need to account for if this component has been added to the stack or not
                Component parent = stack.Peek();
                if (parent == this)
                {
                    parent = stack.Skip(1).FirstOrDefault();
                }
                return parent as TComponent;
            }
            return stack.Where(x => typeof(TComponent).IsAssignableFrom(x.GetType())).FirstOrDefault() as TComponent;
        }

        private Stack<Component> GetComponentStack()
        {
            return GetStack(ComponentStackKey);
        }

        private Stack<Component> GetOutputStack()
        {
            return GetStack(OutputStackKey);
        }

        private Stack<Component> GetStack(object key)
        {
            Stack<Component> stack = Config.GetItem(key, null) as Stack<Component>;
            if (stack == null)
            {
                stack = new Stack<Component>();
                Config.AddItem(key, stack);
            }
            return stack;
        }
    }
}
