using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FluentBootstrap
{
    public abstract class Component : IHtmlString
    {
        private bool _started;
        private bool _ended;

        // Implicit components are created by the library as wrappers, missing tags, etc.
        // The primary difference is that implicit components can be automatically cleaned up from the stack
        private bool _implicit;

        internal BootstrapHelper Helper { get; private set; }

        protected Component(BootstrapHelper helper)
        {
            Helper = helper;
        }

        internal void Start(TextWriter writer, bool @implicit)
        {
            _implicit = @implicit;

            // Only write content once
            if (_started)
                return;
            _started = true;

            // Prepare this component
            Prepare(writer);

            // Add this component to the stack
            Push();

            // Get the content
            OnStart(writer);
        }

        internal void Finish(TextWriter writer)
        {
            // Only write content once
            if (_ended)
                return;
            _ended = true;

            // Remove this component from the stack
            // This must be done before writing the end content in case there are pending components on the stack that need to be ended
            Pop(writer);

            // Get the content
            OnFinish(writer);
        }

        // Use this method to add components to the stack before this one is added
        // Remember that generally you should call .Start() on any components created here
        protected virtual void Prepare(TextWriter writer)
        {
        }

        protected abstract void OnStart(TextWriter writer);

        protected virtual void OnFinish(TextWriter writer)
        {
        }

        // Outputs the start and end portions together
        public virtual string ToHtmlString()
        {
            using (StringWriter writer = new StringWriter())
            {
                Start(writer, false);
                Finish(writer);
                return writer.ToString();
            }
        }

        internal Component Implicit()
        {
            _implicit = true;
            return this;
        }

        // The following code handles the stack of Bootstrap objects stored in the ViewContext

        private readonly static object _bootstrapStackKey = new object();

        private void Push()
        {
            GetStack().Push(this);
        }

        // This also writes end content from any components pending on the stack until this one
        private void Pop(TextWriter writer)
        {
            // Get the stack
            Stack<Component> stack = GetStack();

            // Peek components until we get to this one - the call to Finish() will pop them
            Component peek = null;
            while (stack.Count > 0 && (peek = stack.Peek()) != this && peek._implicit)
            {
                peek.Finish(writer);
            }

            // Sanity check
            if (peek != this)
                throw new InvalidOperationException("A Bootstrap component is finishing but is not at the top of the stack, which is usually an indication that a component has been disposed out of order.");

            // Pop the component from the stack
            if (stack.Pop() != this)
                throw new InvalidOperationException("Popped a different Bootstrap component from the stack (you should never see this).");
        }

        // This pops up the stack if (and only if) it is assignable to the specified type and it (and all intermediate components) are implicit
        // Use this to clear implicitly added components from the stack (see how the table works)
        protected void Pop<TComponent>(TextWriter writer)
        {
            Stack<Component> stack = GetStack();

            // Crawl the stack and queue the components in case an intermediate is not implicit
            Queue<Component> finish = new Queue<Component>();
            if (stack.Count > 0)
            {
                foreach (Component component in stack)
                {
                    if (!component._implicit)
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

        protected TComponent GetComponent<TComponent>()
            where TComponent : Component
        {
            return (TComponent)GetStack().Where(x => typeof(TComponent).IsAssignableFrom(x.GetType())).FirstOrDefault();
        }

        private Stack<Component> GetStack()
        {
            IDictionary items = Helper.HtmlHelper.ViewContext.HttpContext.Items;
            Stack<Component> stack = items[_bootstrapStackKey] as Stack<Component>;
            if (stack == null)
            {
                stack = new Stack<Component>();
                items[_bootstrapStackKey] = stack;
            }
            return stack;
        }
    }
}
