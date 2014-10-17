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
    public interface IComponentCreator<TModel>
    {
        BootstrapHelper<TModel> GetHelper();
        Component GetParent();
    }

    // This wraps a component once it's been output and indicates the available child components
    // If the component does not create any other components, this base ComponentWrapper class can be used
    public abstract class ComponentWrapper<TModel> : IDisposable, IComponentCreator<TModel>
    {
        internal Component<TModel> Component { private get; set; }
        internal bool WithChild { private get; set; }

        public void Dispose()
        {
            Component.End();
        }

        public BootstrapHelper<TModel> GetHelper()
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
    internal interface IComponent
    {
        void Start(TextWriter writer, bool isImplicit = false);
        void Finish(TextWriter writer);
        void StartAndFinish(TextWriter writer);
        bool Implicit { get; }
    }

    public abstract class Component : IComponent
    {
        void IComponent.Start(TextWriter writer, bool isImplicit)
        {
            Start(writer, isImplicit);
        }

        void IComponent.Finish(TextWriter writer)
        {
            Finish(writer);
        }

        void IComponent.StartAndFinish(TextWriter writer)
        {
            StartAndFinish(writer);
        }

        bool IComponent.Implicit
        {
            get { return Implicit; }
        }

        public abstract void End();

        internal abstract void Start(TextWriter writer, bool isImplicit = false);
        internal abstract void Finish(TextWriter writer);
        internal abstract void StartAndFinish(TextWriter writer);
        internal abstract bool Implicit { get; }
        internal abstract void AddChild(IComponent component);
        internal abstract void Begin(TextWriter writer);
        internal abstract void End(TextWriter writer);
    }

    public abstract class Component<TModel> : Component
    {
        internal abstract BootstrapHelper<TModel> Helper { get; }
    }

    public abstract class Component<TModel, TThis, TWrapper> : Component<TModel>, IHtmlString
        where TThis : Component<TModel, TThis, TWrapper>
        where TWrapper : ComponentWrapper<TModel>, new()
    {
        private bool _started;
        private bool _finished;
        private readonly List<IComponent> _children = new List<IComponent>();
        private readonly Component _parent;  // If this is set, all rendering calls get deferred to the parent - see .WithChild() extension
        private readonly BootstrapHelper<TModel> _helper;

        // Implicit components are created by the library as wrappers, missing tags, etc.
        // The primary difference is that implicit components can be automatically cleaned up from the stack
        private bool _implicit;

        internal override bool Implicit
        {
            get { return _implicit; }
        }

        private bool _render = true;

        internal bool Render
        {
            set { _render = value; }
        }

        internal override BootstrapHelper<TModel> Helper
        {
            get { return _helper; }
        }

        internal HtmlHelper<TModel> HtmlHelper
        {
            get { return Helper.HtmlHelper; }
        }

        internal ViewContext ViewContext
        {
            get { return HtmlHelper.ViewContext; }
        }

        internal TThis GetThis()
        {
            return (TThis)this;
        }

        protected Component(IComponentCreator<TModel> creator)
        {
            // Sanity check
            if (typeof(TThis) != this.GetType())
            {
                throw new Exception("Invalid TThis generic type parameter for " + this.GetType().Name + " (you should never see this).");
            }

            _helper = creator.GetHelper();
            _parent = creator.GetParent();
        }

        internal override void AddChild(IComponent component)
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

        internal override void Begin(TextWriter writer)
        {
            // If we have a parent, it needs to be started
            if (_parent != null)
            {
                _parent.Begin(writer);
            }

            Start(writer ?? ViewContext.Writer);
        }

        public override void End()
        {
            End(null);
        }

        internal override void End(TextWriter writer)
        {
            Finish(writer ?? ViewContext.Writer);

            // If we have a parent, it needs to be finished
            if(_parent != null)
            {
                _parent.End(writer);
            }
        }

        // Outputs the start and end portions together
        // This should only be used implicitly in a view and not from within this library (because of the way pending components are handled)
        // Instead, use Component.StartAndFinish() to write out the content of a component during Prepare, OnStart, or OnFinish
        public virtual string ToHtmlString()
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

        internal override void Start(TextWriter writer, bool isImplicit = false)
        {
            // Only write content once
            if (_started)
            {
                return;
            }
            _started = true;

            // Set the implicit flag
            _implicit = isImplicit;

            // Stop now if not rendering
            if (!_render)
            {
                return;
            }

            // Prepare this component
            PreStart(writer);

            // Add this component to the stack
            Push();

            // Get the content
            OnStart(writer);

            // Write any children
            WriteChildren(writer);
        }

        internal override void Finish(TextWriter writer)
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

            // Provide finishing prior to popping from the stack
            PreFinish(writer);

            // Remove this component from the stack
            // This must be done before writing the end content in case there are pending components on the stack that need to be ended
            Pop(writer);

            // Get the content
            OnFinish(writer);
        }

        // This is implicit by definition since it's only ever used inside another component to generate content for a child, etc.
        internal override void StartAndFinish(TextWriter writer)
        {
            Start(writer);
            Finish(writer);
        }

        // This gets called before this component is pushed to the stack
        protected virtual void PreStart(TextWriter writer)
        {
        }

        protected abstract void OnStart(TextWriter writer);

        private void WriteChildren(TextWriter writer)
        {
            foreach (IComponent child in _children)
            {
                child.StartAndFinish(writer);
            }
        }

        // This gets called before this component is popped from the stack
        protected virtual void PreFinish(TextWriter writer)
        {
        }

        protected virtual void OnFinish(TextWriter writer)
        {
        }

        // The following code handles the stack of Bootstrap objects stored in the ViewContext

        private void Push()
        {
            GetStack().Push(this);
        }

        // This also writes end content from any components pending on the stack until this one
        private void Pop(TextWriter writer)
        {
            // Get the stack
            Stack<IComponent> stack = GetStack();

            // Peek components until we get to this one - the call to Finish() will pop them
            IComponent peek = null;
            while (stack.Count > 0 && (peek = stack.Peek()) != this && peek.Implicit)
            {
                peek.Finish(writer);
            }

            // Sanity check
            if (peek != this)
                throw new InvalidOperationException("A Bootstrap component is finishing but is not at the top of the stack, " +
                    "which is usually an indication that a component has been disposed out of order " +
                    "or that more than one component was created in a single using statement.");

            // Pop the component from the stack
            IComponent pop = stack.Pop();
            if (pop != this)
                throw new InvalidOperationException("Popped a different Bootstrap component from the stack (you should never see this).");
        }

        // This pops up the stack if (and only if) it is assignable to the specified type
        // Use this to clear arbitrary implicitly added components from the stack (see how Tables.Row works)
        internal void Pop<TComponent>(TextWriter writer)
            where TComponent : IComponent
        {
            Stack<IComponent> stack = GetStack();

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
                return;
            Stack<IComponent> stack = GetStack();

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
        // Using a type that has TModel will skip components with a different model (such as when run from inside a partial with a different model)
        // onlyParent indicates that just the parent component in the stack should be searched (instead of all the way up)
        internal TComponent GetComponent<TComponent>(bool onlyParent = false)
            where TComponent : class, IComponent
        {
            Stack<IComponent> stack = GetStack();
            if(onlyParent)
            {
                // Need to account for if this component has been added to the stack or not
                IComponent parent =stack.Peek();
                if(parent == this)
                {
                    parent = stack.Skip(1).FirstOrDefault();
                }
                return parent as TComponent;
            }
            return stack.Where(x => typeof(TComponent).IsAssignableFrom(x.GetType())).FirstOrDefault() as TComponent;
        }

        private Stack<IComponent> GetStack()
        {
            IDictionary items = ViewContext.HttpContext.Items;
            Stack<IComponent> stack = items[Bootstrap.ComponentStackKey] as Stack<IComponent>;
            if (stack == null)
            {
                stack = new Stack<IComponent>();
                items[Bootstrap.ComponentStackKey] = stack;
            }
            return stack;
        }
    }
}
