using FluentBootstrap.Navs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class NavExtensions
    {  
        // Pills

        public static ComponentBuilder<TConfig, Pills> Pills<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Pills>
        {
            return new ComponentBuilder<TConfig, Pills>(helper.Config, new Pills(helper));
        }

        public static ComponentBuilder<TConfig, Pills> SetStacked<TConfig>(this ComponentBuilder<TConfig, Pills> builder, bool stacked = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.ToggleCss(Css.NavStacked, stacked);
            return builder;
        }

        public static ComponentBuilder<TConfig, Pill> Pill<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text, string href = "#")
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Pill>
        {
            return new ComponentBuilder<TConfig, Pill>(helper.Config, new Pill(helper))
                .SetHref(href)
                .SetText(text);
        }

        // Tabs

        public static ComponentBuilder<TConfig, Tabs> Tabs<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tabs>
        {
            return new ComponentBuilder<TConfig, Tabs>(helper.Config, new Tabs(helper));
        }

        public static ComponentBuilder<TConfig, Tab> Tab<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text, string href = "#")
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tab>
        {
            return new ComponentBuilder<TConfig, Tab>(helper.Config, new Tab(helper))
                .SetHref(href)
                .SetText(text);
        }

        // Nav/NavLink

        public static ComponentBuilder<TConfig, TNavLink> SetActive<TConfig, TNavLink>(this ComponentBuilder<TConfig, TNavLink> builder, bool active = true)
            where TConfig : BootstrapConfig
            where TNavLink : NavLink
        {
            builder.Component.Active = active;
            return builder;
        }

        public static ComponentBuilder<TConfig, TNavLink> SetDisabled<TConfig, TNavLink>(this ComponentBuilder<TConfig, TNavLink> builder, bool disabled = true)
            where TConfig : BootstrapConfig
            where TNavLink : NavLink
        {
            builder.Component.Disabled = disabled;
            return builder;
        }

        public static ComponentBuilder<TConfig, TNav> SetJustified<TConfig, TNav>(this ComponentBuilder<TConfig, TNav> builder, bool justified = true)
            where TConfig : BootstrapConfig
            where TNav : Nav
        {
            builder.Component.ToggleCss(Css.NavJustified, justified);
            return builder;
        }
    }
}
