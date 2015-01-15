using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentBootstrap.Links;
using System.Web.Routing;

namespace FluentBootstrap
{
    public static class LinkExtensions
    {
        // Link

        public static ComponentBuilder<TConfig, Link> Link<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text, string href = "#")
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Link>
        {
            return new ComponentBuilder<TConfig, Link>(helper.Config, new Link(helper)).SetHref(href).SetText(text);
        }

        // IHasLinkExtensions

        public static ComponentBuilder<TConfig, TTag> SetHref<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, string href)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasLinkExtensions
        {
            if (!string.IsNullOrWhiteSpace(href))
            {
                builder.Component.MergeAttribute("href", href);
            }
            return builder;
        }
    }
}
