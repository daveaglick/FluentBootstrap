using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class ComponentExtensions
    {
        public static ComponentBuilder<TConfig, TComponent> RenderIf<TConfig, TComponent>(this ComponentBuilder<TConfig, TComponent> builder, bool condition)
            where TConfig : BootstrapConfig
            where TComponent : Component
        {
            builder.Component.Render = condition;
            return builder;
        }
    }
}
