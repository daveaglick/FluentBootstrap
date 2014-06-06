using System;
using System.Collections.Generic;
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

        internal string Start()
        {
            // Only write content once
            if (_started)
                throw new InvalidOperationException("This component has already generated starting content.");
            _started = true;

            // Add this component to the stack
            Helper.PushComponent(this);

            // Return the content
            return OnStart();
        }

        internal string End()
        {
            // Only write content once
            if (_ended)
                throw new InvalidOperationException("This component has already generated ending content.");
            _ended = true;

            // Get the content
            string end = OnEnd();

            // Remove this component from the stack
            Helper.PopComponent(this);

            return end;
        }

        protected abstract string OnStart();

        protected virtual string OnEnd()
        {
            return string.Empty;
        }

        // Outputs the start and end portions together
        public virtual string ToHtmlString()
        {
            return Start() + End();
        }
    }
}
