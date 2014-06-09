using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FluentBootstrap
{
    public class ComponentWrapper<TComponent> : IDisposable, IHtmlString
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

        public string ToHtmlString()
        {
            throw new InvalidOperationException("A component was converted to a string, which is usually an indication that the Html.Bootstrap(b => b.Component()) method was used instead of Html.Bootstrap().Component().");
        }

        public void Dispose()
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().Name);
            _disposed = true;
            if(_endOnDispose)
                Component.End(Component.Helper.ViewContextWriter);
        }
    }
}
