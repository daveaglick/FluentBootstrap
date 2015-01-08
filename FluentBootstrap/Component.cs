using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FluentBootstrap
{
    // TODO: Can this be made internal?
    public interface IComponentCreator
    {
        BootstrapHelper GetHelper();
        Component GetParent();
    }

    public interface IComponentCreator<THelper, TComponent> : IComponentCreator
        where THelper : BootstrapHelper<THelper>
        where TComponent : Component
    {
        THelper Helper { get; }
    }

    public abstract class ComponentBuilder
    {
        internal abstract Component GetComponent();
    }

    public class ComponentBuilder<THelper, TComponent> : ComponentBuilder, IHtmlString
        where THelper : BootstrapHelper<THelper>
        where TComponent : Component
    {
        private readonly THelper _helper;
        private readonly TComponent _component;

        internal ComponentBuilder(THelper helper, TComponent component)
        {
            _component = component;
            _helper = helper;
        }

        internal THelper Helper
        {
            get { return this._helper; }
        }

        internal TComponent Component
        {
            get { return this._component; }
        }

        internal override Component GetComponent()
        {
            return Component;
        }

        internal ComponentWrapper<THelper, TComponent> GetWrapper()
        {
            return new ComponentWrapper<THelper, TComponent>(this);
        }

        public ComponentWrapper<THelper, TComponent> Begin()
        {
            Component.Begin(Helper, null);
            return GetWrapper();
        }

        public void End()
        {
            Component.End(Helper, null);
        }

        public string ToHtmlString()
        {
            return ToString();
        }

        public override string ToString()
        {
            return Component.ToString(Helper);
        }
    }

    public class ComponentWrapper<THelper, TComponent> : IDisposable,
        IComponentCreator<THelper, TComponent>
        where THelper : BootstrapHelper<THelper>
        where TComponent : Component
    {
        private readonly ComponentBuilder<THelper, TComponent> _builder;

        internal ComponentWrapper(ComponentBuilder<THelper, TComponent> builder)
        {
            _builder = builder;
        }

        internal bool WithChild { get; set; }


        public void Dispose()
        {
            End();
        }

        public void End()
        {
            _builder.End();
        }

        BootstrapHelper IComponentCreator.GetHelper()
        {
            return _builder.Helper;
        }

        Component IComponentCreator.GetParent()
        {
            return WithChild ? _builder.Component : null;
        }

        THelper IComponentCreator<THelper, TComponent>.Helper
        {
            get { return _builder.Helper; }
        }
    }

    public abstract class Component
    {
        protected readonly static object ComponentStackKey = new object();
        protected readonly static object OutputStackKey = new object();
        protected readonly static object TagIndentKey = new object();
        protected readonly static object LastToWriteKey = new object();

        private bool _started;
        private bool _finished;
        private readonly List<Component> _children = new List<Component>();
        private readonly Component _parent;  // If this is set, all rendering calls get deferred to the parent - see .WithChild() extension

        // Implicit components are created by the library as wrappers, missing tags, etc.
        // The primary difference is that implicit components can be automatically cleaned up from the stack
        private readonly bool _implicit;

        internal bool Implicit
        {
            get { return _implicit; }
        }

        private bool _render = true;

        internal bool Render
        {
            set { _render = value; }
        }

        protected Component(IComponentCreator creator)
        {
            _parent = creator.GetParent();
            _implicit = GetOutputStack(creator.GetHelper()).Count > 0;
        }

        // Gets a temporary ComponentBuilder that can be used to access extension methods from overrides
        // Needs to be static since it can't know the current component type unless passed in
        // Generally you'll pass in "this" for the component argument
        protected static ComponentBuilder<THelper, TComponent> GetBuilder<THelper, TComponent>(THelper helper, TComponent component)
            where THelper : BootstrapHelper<THelper>
            where TComponent : Component
        {
            return new ComponentBuilder<THelper, TComponent>(helper, component);
        }

        internal void AddChild(Component child)
        {
            _children.Add(child);
        }

        internal void Begin<THelper>(THelper helper, TextWriter writer)
            where THelper : BootstrapHelper<THelper>
        {
            // If we have a parent, it needs to be started
            if (_parent != null)
            {
                _parent.Begin(helper, writer);
            }

            Start(helper, writer ?? helper.GetWriter());
        }

        internal void End<THelper>(THelper helper, TextWriter writer)
            where THelper : BootstrapHelper<THelper>
        {
            Finish(helper, writer ?? helper.GetWriter());

            // If we have a parent, it needs to be finished
            if (_parent != null)
            {
                _parent.End(helper, writer);
            }
        }

        // This should only be used implicitly in a view and not from within this library (because of the way pending components are handled)
        // Instead, use Component.StartAndFinish() to write out the content of a component during Prepare, OnStart, or OnFinish
        internal string ToString<THelper>(THelper helper)
            where THelper : BootstrapHelper<THelper>
        {
            // Write this component out as a string
            using (StringWriter writer = new StringWriter())
            {
                // If we have a parent, it needs to be started
                if (_parent != null)
                {
                    _parent.Begin(helper, writer);
                }

                StartAndFinish(helper, writer);

                // If we have a parent, it needs to be finished
                if (_parent != null)
                {
                    _parent.End(helper, writer);
                }

                return writer.ToString();
            }
        }

        internal void Start<THelper>(THelper helper, TextWriter writer)
            where THelper : BootstrapHelper<THelper>
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
            GetOutputStack(helper).Push(this);

            // Output the content
            //if (_componentOverrides.Count > 0)
            //{
            //    _componentOverrides.Peek().OnStart(writer);
            //}
            //else
            {
                OnStart(helper, writer);
            }

            // Clear this component from the output stack
            if (GetOutputStack(helper).Pop() != this)
            {
                throw new InvalidOperationException("Popped a different Bootstrap component from the output stack while starting (you should never see this).");
            }

            // Write any children
            WriteChildren(helper, writer);
        }

        internal void Finish<THelper>(THelper helper, TextWriter writer)
            where THelper : BootstrapHelper<THelper>
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

            // Get the stack
            Stack<Component> stack = GetComponentStack(helper);

            // Peek components until we get to this one - the call to Finish() will pop them
            Component peek = null;
            while (stack.Count > 0 && (peek = stack.Peek()) != this && peek.Implicit)
            {
                peek.Finish(helper, writer);
            }

            // Sanity check
            if (peek != this)
            {
                throw new InvalidOperationException("A Bootstrap component is finishing but is not at the top of the stack, " +
                    "which is usually an indication that a component has been disposed out of order " +
                    "or that more than one component was created in a single using statement.");
            }

            // Note that this component is outputting
            GetOutputStack(helper).Push(this);

            // Output the content
            //if (_componentOverrides.Count > 0)
            //{
            //    _componentOverrides.Peek().OnFinish(writer);
            //}
            //else
            {
                OnFinish(helper, writer);
            }

            // Clear this component from the output stack
            if (GetOutputStack(helper).Pop() != this)
            {
                throw new InvalidOperationException("Popped a different Bootstrap component from the output stack while finishing (you should never see this).");
            }
        }

        // This is implicit by definition since it's only ever used inside another component to generate content for a child, etc.
        internal void StartAndFinish<THelper>(THelper helper, TextWriter writer)
            where THelper : BootstrapHelper<THelper>
        {
            Start(helper, writer);
            Finish(helper, writer);
        }

        // This must be called from overloads as it adds the component to the stack
        // To suppress output, pass in SuppressOutputWriter
        protected virtual void OnStart<THelper>(THelper helper, TextWriter writer)
            where THelper : BootstrapHelper<THelper>
        {
            Push(helper);
        }

        // This must be called from overloads as it removes the component from the stack
        // To suppress output, pass in SuppressOutputWriter
        protected virtual void OnFinish<THelper>(THelper helper, TextWriter writer)
            where THelper : BootstrapHelper<THelper>
        {
            // Get the stack
            Stack<Component> stack = GetComponentStack(helper);

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

        private void WriteChildren<THelper>(THelper helper, TextWriter writer)
            where THelper : BootstrapHelper<THelper>
        {
            foreach (Component child in _children.Cast<Component>())
            {
                child.StartAndFinish(helper, writer);
            }
        }

        // The following code handles the stack of Bootstrap objects stored in the ViewContext

        private void Push<THelper>(THelper helper)
            where THelper : BootstrapHelper<THelper>
        {
            GetComponentStack(helper).Push(this);
        }

        // This pops up the stack if (and only if) it is assignable to the specified type
        // Use this to clear arbitrary implicitly added components from the stack (see how Tables.Row works)
        internal void Pop<THelper, TComponent>(THelper helper, TextWriter writer)
            where THelper : BootstrapHelper<THelper>
            where TComponent : Component
        {
            Stack<Component> stack = GetComponentStack(helper);

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
                            finish.Dequeue().Finish(helper, writer);
                        }
                        break;
                    }
                }
            }
        }

        // This pops up the stack if (and only if) the requested component and all intermediate components are implicit
        // Use this to clear specific implicitly added components from the stack (see how Forms.Input works)
        internal void Pop<THelper>(THelper helper, Component pop, TextWriter writer)
            where THelper : BootstrapHelper<THelper>
        {
            if (pop == null || !pop.Implicit)
            {
                return;
            }
            Stack<Component> stack = GetComponentStack(helper);

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
                            finish.Dequeue().Finish(helper, writer);
                        }
                        break;
                    }
                }
            }
        }

        // onlyParent indicates that just the parent component in the stack should be searched (instead of all the way up)
        internal TComponent GetComponent<TComponent>(BootstrapHelper helper, bool onlyParent = false)
            where TComponent : Component
        {
            Stack<Component> stack = GetComponentStack(helper);
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

        private Stack<Component> GetComponentStack(BootstrapHelper helper)
        {
            return GetStack(helper, ComponentStackKey);
        }

        private Stack<Component> GetOutputStack(BootstrapHelper helper)
        {
            return GetStack(helper, OutputStackKey);
        }

        private Stack<Component> GetStack(BootstrapHelper helper, object key)
        {
            Stack<Component> stack = helper.GetItem(key, null) as Stack<Component>;
            if (stack == null)
            {
                stack = new Stack<Component>();
                helper.AddItem(key, stack);
            }
            return stack;
        }
    }
}
