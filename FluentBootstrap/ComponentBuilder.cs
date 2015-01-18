using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace FluentBootstrap
{
    public abstract class ComponentBuilder
    {
        internal abstract BootstrapConfig GetConfig();
        internal abstract Component GetComponent();
    }

    public class ComponentBuilder<TConfig, TComponent> : ComponentBuilder, IHtmlString
        where TConfig : BootstrapConfig
        where TComponent : Component
    {
        private readonly TConfig _config;
        private readonly TComponent _component;

        public ComponentBuilder(TConfig config, TComponent component)
        {
            _component = component;
            _config = config;
        }

        internal TConfig Config
        {
            get { return _config; }
        }

        internal override BootstrapConfig GetConfig()
        {
            return Config;
        }

        internal TComponent Component
        {
            get { return _component; }
        }

        internal override Component GetComponent()
        {
            return Component;
        }

        internal ComponentWrapper<TConfig, TComponent> GetWrapper()
        {
            return new ComponentWrapper<TConfig, TComponent>(_config, _component);
        }

        // This gets a dummy BootstrapHelper that can be used to create new components with the same config as this one
        public BootstrapHelper<TConfig, CanCreate> GetHelper()
        {
            return new DummyBootstrapHelper(Config);
        }

        private class DummyBootstrapHelper : BootstrapHelper<TConfig, CanCreate>
        {
            public DummyBootstrapHelper(TConfig config)
                : base(config)
            {
            }
        }

        public ComponentWrapper<TConfig, TComponent> Begin()
        {
            Component.Begin(null);
            return GetWrapper();
        }

        public string ToHtmlString()
        {
            return ToString();
        }

        public override string ToString()
        {
            return Component.ToString();
        }
    }
}
