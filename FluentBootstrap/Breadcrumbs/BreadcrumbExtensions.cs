using FluentBootstrap.Breadcrumbs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class BreadcrumbExtensions
    {
        public static ComponentBuilder<TConfig, Breadcrumb> Breadcrumb<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Breadcrumb>
        {
            return new ComponentBuilder<TConfig, Breadcrumb>(helper.Config, new Breadcrumb(helper));
        }

        public static ComponentBuilder<TConfig, Crumb> Crumb<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text, string href = "#")
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Crumb>
        {
            return new ComponentBuilder<TConfig, Crumb>(helper.Config, new Crumb(helper))
                .SetHref(href).SetText(text);
        }

        public static ComponentBuilder<TConfig, Crumb> SetActive<TConfig>(this ComponentBuilder<TConfig, Crumb> builder, bool active = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.Active = active;
            return builder;
        }
    }
}
