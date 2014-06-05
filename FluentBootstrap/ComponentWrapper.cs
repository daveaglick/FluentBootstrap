using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public class ComponentWrapper<TComponent> : IDisposable
        where TComponent : BootstrapComponent
    {
        private bool _disposed;

        internal TComponent Component { get; private set; }

        internal ComponentWrapper(TComponent component)
        {
            Component = component;
        }

        public void Dispose()
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().Name);
            _disposed = true;
            Component.Helper.Write(Component.End());
        }
    }
}
