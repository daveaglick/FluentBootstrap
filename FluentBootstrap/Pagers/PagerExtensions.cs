using FluentBootstrap.Pagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class PagerExtensions
    {
        // Pager

        public static ComponentBuilder<TConfig, Pager> Pager<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Pager>
        {
            return new ComponentBuilder<TConfig, Pager>(helper.Config, new Pager(helper));
        }

        public static ComponentBuilder<TConfig, Pager> AddPrevious<TConfig>(this ComponentBuilder<TConfig, Pager> builder, string text, string href = "#", bool disabled = false)
            where TConfig : BootstrapConfig
        {
            builder.AddChild(x => x.Page(text, href).SetAlignment(PageAlignment.Previous).SetDisabled(disabled));
            return builder;
        }

        public static ComponentBuilder<TConfig, Pager> AddNext<TConfig>(this ComponentBuilder<TConfig, Pager> builder, string text, string href = "#", bool disabled = false)
            where TConfig : BootstrapConfig
        {
            builder.AddChild(x => x.Page(text, href).SetAlignment(PageAlignment.Next).SetDisabled(disabled));
            return builder;
        }

        public static ComponentBuilder<TConfig, Pager> AddPage<TConfig>(this ComponentBuilder<TConfig, Pager> builder, string text, string href = "#", bool disabled = false)
            where TConfig : BootstrapConfig
        {
            builder.AddChild(x => x.Page(text, href).SetDisabled(disabled));
            return builder;
        }
        
        // Page

        public static ComponentBuilder<TConfig, Page> Page<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text, string href = "#")
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Page>
        {
            return new ComponentBuilder<TConfig, Page>(helper.Config, new Page(helper))
                .SetHref(href)
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, Page> SetDisabled<TConfig>(this ComponentBuilder<TConfig, Page> builder, bool disabled = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.Disabled = disabled;
            return builder;
        }

        public static ComponentBuilder<TConfig, Page> SetAlignment<TConfig>(this ComponentBuilder<TConfig, Page> builder, PageAlignment alignment)
            where TConfig : BootstrapConfig
        {
            builder.Component.Alignment = alignment;
            return builder;
        }
    }
}
