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
        private readonly bool _writeOnDispose;

        internal TComponent Component { get; private set; }

        internal ComponentWrapper(TComponent component, bool writeOnDispose = true)
        {
            Component = component;
            this._writeOnDispose = writeOnDispose;
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
            if(_writeOnDispose)
                Component.Helper.Write(Component.End());
        }
    }
}
