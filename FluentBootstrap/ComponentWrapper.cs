using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FluentBootstrap
{
    public class ComponentWrapper<TComponent> : IDisposable, IHtmlString, IComponentCreator<TComponent>
        where TComponent : Component
    {
        private bool _disposed;
        private readonly bool _endOnDispose;

        internal TComponent Component { get; private set; }

        // endOnDispose is used when creating dummy wrappers for extension method purposes and they're not actually supposed to write (or do anything else)
        internal ComponentWrapper(TComponent component, bool endOnDispose = true)
        {
            Component = component;
            this._endOnDispose = endOnDispose;
        }

        public BootstrapHelper GetHelper()
        {
            return Component.Helper;
        }

        // We shouldn't ever really try to convert a disposable component directly to a string, but just in case
        public string ToHtmlString()
        {
            return Component.ToHtmlString();
        }

        public void Dispose()
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().Name);
            _disposed = true;
            if(_endOnDispose)
                Component.Finish(Component.ViewContext.Writer);
        }
    }
}
