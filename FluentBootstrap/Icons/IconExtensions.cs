using FluentBootstrap.Html;
using FluentBootstrap.Icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class IconExtensions
    {
        public static ComponentBuilder<TConfig, IconSpan> Icon<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, Icon icon)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<IconSpan>
        {
            return new ComponentBuilder<TConfig, IconSpan>(helper.Config, new IconSpan(helper, icon));
        }

        // IHasIconExtensions

        public static ComponentBuilder<TConfig, TTag> SetIcon<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, Icon icon)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasIconExtensions
        {
            if (icon != FluentBootstrap.Icon.None)
            {
                builder.Component.AddChild(builder.GetHelper().Icon(icon));
                builder.Component.AddChild(builder.GetHelper().Content(" ")); // Add a space to give a little separation to the icon
            }
            return builder;
        }
    }
}
