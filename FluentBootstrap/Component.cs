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
    public abstract class Component : IDisposable, IHtmlString
    {
        private bool _started;
        private bool _ended;

        internal BootstrapHelper Helper { get; private set; }

        public Component(BootstrapHelper helper)
        {
            Helper = helper;
        }

        public void Dispose()
        {
            throw new InvalidOperationException("A component was directly disposed, which is usually an indication that the Html.Bootstrap().Component() method was used instead of Html.Bootstrap(b => b.Component()).");
        }

        internal void Start(TextWriter writer)
        {
            // Prepare this component
            Prepare(writer);

            // Only write content once
            if (_started)
                throw new InvalidOperationException("This component has already generated starting content.");
            _started = true;

            // Get the content
            OnStart(writer);

            // Add this component to the stack
            Push();
        }

        internal void End(TextWriter writer)
        {
            // Only write content once
            if (_ended)
                throw new InvalidOperationException("This component has already generated ending content.");
            _ended = true;

            // Remove this component from the stack
            Pop(writer);

            // Get the content
            OnEnd(writer);
        }

        // Use this method to add components to the stack before this one is added
        // Remember that generally you should call .Start() on any components created here
        protected virtual void Prepare(TextWriter writer)
        {
        }

        protected abstract void OnStart(TextWriter writer);

        protected virtual void OnEnd(TextWriter writer)
        {
        }

        // Outputs the start and end portions together
        public virtual string ToHtmlString()
        {
            using (StringWriter writer = new StringWriter())
            {
                Start(writer);
                End(writer);
                return writer.ToString();
            }
        }

        // The following code handles the stack of Bootstrap objects stored in the ViewContext

        private readonly static object _bootstrapStackKey = new object();

        private void Push()
        {
            IDictionary items = Helper.HtmlHelper.ViewContext.HttpContext.Items;
            Stack<Component> stack = items[_bootstrapStackKey] as Stack<Component>;
            if (stack == null)
            {
                stack = new Stack<Component>();
                items[_bootstrapStackKey] = stack;
            }
            stack.Push(this);
        }

        // This also writes end content from any components pending on the stack until this one
        private void Pop(TextWriter writer)
        {
            // Get the stack
            IDictionary items = Helper.HtmlHelper.ViewContext.HttpContext.Items;
            Stack<Component> stack = items[_bootstrapStackKey] as Stack<Component>;
            if (stack == null)
                throw new InvalidOperationException("Could not get Bootstrap component stack while removing a component (you should never see this).");

            // Pop components until we get to the requested one
            Component pop = null;
            while (stack.Count > 0 && (pop = stack.Pop()) != this)
            {
                pop.End(writer);
            }

            // Sanity check
            if (stack.Count == 0 && pop != this)
                throw new InvalidOperationException("Removed all Bootstrap components from the stack, this is usually an indication that one was not disposed in the correct nesting order.");
        }

        protected TComponent GetComponent<TComponent>()
            where TComponent : Component
        {
            IDictionary items = Helper.HtmlHelper.ViewContext.HttpContext.Items;
            Stack<Component> stack = items[_bootstrapStackKey] as Stack<Component>;
            return stack == null ? null : stack.OfType<TComponent>().FirstOrDefault();
        }
    }
}
