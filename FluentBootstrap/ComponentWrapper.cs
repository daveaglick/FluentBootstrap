using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentBootstrap
{
    public class ComponentWrapper<TConfig, TComponent> : BootstrapHelper<TConfig, TComponent>, IDisposable
        where TConfig : BootstrapConfig
        where TComponent : Component
    {
        private readonly TComponent _component;

        protected internal ComponentWrapper(TConfig config, TComponent component)
            : base(config)
        {
            _component = component;
        }

        public void Dispose()
        {
            End();
        }

        public void End()
        {
            _component.End(null);
        }

        internal bool WithChild { get; set; }

        internal override Component GetParent()
        {
            return WithChild ? _component : null;
        }
    }
}
