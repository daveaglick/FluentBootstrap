using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FluentBootstrap
{
    // This is applied to wrappers to indicate that they can create a particular component
    public interface IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
        THelper GetHelper();
        Component GetParent();
    }    

    // This wraps a component once it's been output and indicates the available child components
    // If the component does not create any other components, this base ComponentWrapper class can be used
    public abstract class ComponentWrapper<THelper> : IDisposable, IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
        internal Component<THelper> Component { get; set; }
        internal bool WithChild { get; set; }

        public void Dispose()
        {
            Component.End();
        }

        public THelper GetHelper()
        {
            return Component.Helper;
        }

        public Component GetParent()
        {
            return WithChild ? Component : null;
        }
    }

    // This (and derived) non-generic interfaces are needed for every component
    // They allow type comparisons of component references without worrying about all the generic stuff
    // Generally, any members that need to be accessed after getting a component off the stack from another one should be put in this interface
    internal interface IComponentInternals
    {
        void Start(TextWriter writer);
        void Finish(TextWriter writer);
        void StartAndFinish(TextWriter writer);
        bool Implicit { get; }
    }

    public interface IComponent : IComponentInternals
    {
    }

    public abstract class Component : IComponent
    {
        void IComponentInternals.Start(TextWriter writer)
        {
            Start(writer);
        }

        void IComponentInternals.Finish(TextWriter writer)
        {
            Finish(writer);
        }

        void IComponentInternals.StartAndFinish(TextWriter writer)
        {
            StartAndFinish(writer);
        }

        bool IComponentInternals.Implicit
        {
            get { return Implicit; }
        }

        public abstract void End();

        internal abstract void Start(TextWriter writer);
        internal abstract void Finish(TextWriter writer);
        internal abstract void StartAndFinish(TextWriter writer);
        internal abstract bool Implicit { get; }
        internal abstract void AddChild(IComponent component);
        internal abstract void Begin(TextWriter writer);
        internal abstract void End(TextWriter writer);
    }

    public abstract class Component<THelper> : Component
        where THelper : BootstrapHelper<THelper>
    {
        internal abstract THelper Helper { get; }
    }

    public abstract class Component<THelper, TThis, TWrapper> : Component<THelper>, IHtmlString
        where THelper : BootstrapHelper<THelper>
        where TThis : Component<THelper, TThis, TWrapper>
        where TWrapper : ComponentWrapper<THelper>, new()
    {
        private bool _started;
        private bool _finished;
        private readonly List<IComponent> _children = new List<IComponent>();
        private readonly Component _parent;  // If this is set, all rendering calls get deferred to the parent - see .WithChild() extension
        private readonly THelper _helper;

        // Implicit components are created by the library as wrappers, missing tags, etc.
        // The primary difference is that implicit components can be automatically cleaned up from the stack
        private readonly bool _implicit;

        internal override sealed bool Implicit
        {
            get { return _implicit; }
        }

        private bool _render = true;

        internal bool Render
        {
            set { _render = value; }
        }

        internal override sealed THelper Helper
        {
            get { return _helper; }
        }

        internal TThis GetThis()
        {
            return (TThis)this;
        }

        protected Component(IComponentCreator<THelper> creator)
        {
            // Sanity check
            if (typeof(TThis) != this.GetType())
            {
                throw new Exception("Invalid TThis generic type parameter for " + this.GetType().Name + " (you should never see this).");
            }

            _helper = creator.GetHelper();
            _parent = creator.GetParent();
            _implicit = Helper.OutputContext.GetOutputStack().Count > 0;
        }

        internal override sealed void AddChild(IComponent component)
        {
            _children.Add(component);
        }

        internal TWrapper GetWrapper()
        {
            TWrapper wrapper = new TWrapper();
            wrapper.Component = this;
            return wrapper;
        }

        public TWrapper Begin()
        {
            Begin(null);
            return GetWrapper();
        }

        internal override sealed void Begin(TextWriter writer)
        {
            // If we have a parent, it needs to be started
            if (_parent != null)
            {
                _parent.Begin(writer);
            }

            Start(writer ?? Helper.OutputContext.GetWriter());
        }

        public override sealed void End()
        {
            End(null);
        }

        internal override sealed void End(TextWriter writer)
        {
            Finish(writer ?? Helper.OutputContext.GetWriter());

            // If we have a parent, it needs to be finished
            if(_parent != null)
            {
                _parent.End(writer);
            }
        }

        // Outputs the start and end portions together
        // This should only be used implicitly in a view and not from within this library (because of the way pending components are handled)
        // Instead, use Component.StartAndFinish() to write out the content of a component during Prepare, OnStart, or OnFinish
        public string ToHtmlString()
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

        public override string ToString()
        {
            return ToHtmlString();
        }

        internal override sealed void Start(TextWriter writer)
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
            Helper.OutputContext.GetOutputStack().Push(this);

            // Output the content
            OnStart(writer);

            // Clear this component from the output stack
            if (Helper.OutputContext.GetOutputStack().Pop() != this)
            {
                throw new InvalidOperationException("Popped a different Bootstrap component from the output stack while starting (you should never see this).");
            }

            // Write any children
            WriteChildren(writer);
        }

        internal override sealed void Finish(TextWriter writer)
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

            // Note that this component is outputting
            Helper.OutputContext.GetOutputStack().Push(this);

            // Output the content
            OnFinish(writer);

            // Clear this component from the output stack
            if (Helper.OutputContext.GetOutputStack().Pop() != this)
            {
                throw new InvalidOperationException("Popped a different Bootstrap component from the output stack while finishing (you should never see this).");
            }

        }

        // This is implicit by definition since it's only ever used inside another component to generate content for a child, etc.
        internal override sealed void StartAndFinish(TextWriter writer)
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
            Pop(writer);
        }

        private void WriteChildren(TextWriter writer)
        {
            foreach (IComponent child in _children)
            {
                child.StartAndFinish(writer);
            }
        }


        // The following code handles the stack of Bootstrap objects stored in the ViewContext

        private void Push()
        {
            Helper.OutputContext.GetComponentStack().Push(this);
        }

        // This also writes end content from any components pending on the stack until this one
        private void Pop(TextWriter writer)
        {
            // Get the stack
            Stack<IComponent> stack = Helper.OutputContext.GetComponentStack();

            // Peek components until we get to this one - the call to Finish() will pop them
            IComponent peek = null;
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

            // Pop the component from the stack
            IComponent pop = stack.Pop();
            if (pop != this)
            {
                throw new InvalidOperationException("Popped a different Bootstrap component from the component stack (you should never see this).");
            }
        }

        // This pops up the stack if (and only if) it is assignable to the specified type
        // Use this to clear arbitrary implicitly added components from the stack (see how Tables.Row works)
        internal void Pop<TComponent>(TextWriter writer)
            where TComponent : IComponent
        {
            Stack<IComponent> stack = Helper.OutputContext.GetComponentStack();

            // Crawl the stack and queue the components in case an intermediate is not implicit
            Queue<IComponent> finish = new Queue<IComponent>();
            if (stack.Count > 0)
            {
                foreach (IComponent component in stack)
                {
                    if(component == this)
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
        internal void Pop(IComponent pop, TextWriter writer)
        {
            if (pop == null || !pop.Implicit)
            {
                return;
            }
            Stack<IComponent> stack = Helper.OutputContext.GetComponentStack();

            // Crawl the stack and queue the components in case an intermediate is not implicit
            Queue<IComponent> finish = new Queue<IComponent>();
            if (stack.Count > 0)
            {
                foreach (IComponent component in stack)
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

        // Only the simple interface types should be used as generic type parameters here
        // Using a type that has THelper will skip components with a different model (such as when run from inside a partial with a different model)
        // onlyParent indicates that just the parent component in the stack should be searched (instead of all the way up)
        internal TComponent GetComponent<TComponent>(bool onlyParent = false)
            where TComponent : class, IComponent
        {
            Stack<IComponent> stack = Helper.OutputContext.GetComponentStack();
            if(onlyParent)
            {
                // Need to account for if this component has been added to the stack or not
                IComponent parent = stack.Peek();
                if(parent == this)
                {
                    parent = stack.Skip(1).FirstOrDefault();
                }
                return parent as TComponent;
            }
            return stack.Where(x => typeof(TComponent).IsAssignableFrom(x.GetType())).FirstOrDefault() as TComponent;
        }
    }
}
