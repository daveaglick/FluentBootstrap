using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentBootstrap
{
    public class ComponentWrapper<TComponent> : IDisposable, IComponentCreator<TComponent>
        where TComponent : Component
    {
        private readonly ComponentBuilder _builder;

        protected internal ComponentWrapper(ComponentBuilder builder)
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

        public BootstrapHelper Helper
        {
            get { return _builder.Helper; }
        }

        public Component Parent
        {
            get { return WithChild ? _builder.GetComponent() : null; }
        }
    }
}
