using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{    
    public abstract class BootstrapHelper
    {
        internal abstract BootstrapConfig GetConfig();

        internal virtual Component GetParent()
        {
            return null;
        }
    }

    public abstract class BootstrapHelper<TConfig, TComponent> : BootstrapHelper
        where TConfig : BootstrapConfig
        where TComponent : Component
    {
        private readonly TConfig _config;

        protected BootstrapHelper(TConfig config)
        {
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

        // This allows an alternate syntax by using a func inside the Begin method
        public ComponentWrapper<TConfig, TNewComponent> Begin<TNewComponent>(Func<BootstrapHelper<TConfig, TComponent>, ComponentBuilder<TConfig, TNewComponent>> component)
            where TNewComponent : Component
        {
            return component(this).Begin();
        }
    }
}
