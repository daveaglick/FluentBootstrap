using FluentBootstrap.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class PaginationExtensions
    {
        // Pagination

        public static ComponentBuilder<TConfig, Pagination> Pagination<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Pagination>
        {
            return new ComponentBuilder<TConfig, Pagination>(helper.Config, new Pagination(helper));
        }

        public static ComponentBuilder<TConfig, Pagination> SetSize<TConfig>(this ComponentBuilder<TConfig, Pagination> builder, PaginationSize size)
            where TConfig : BootstrapConfig
        {
            builder.Component.ToggleCss(size);
            return builder;
        }

        public static ComponentBuilder<TConfig, Pagination> AddPrevious<TConfig>(this ComponentBuilder<TConfig, Pagination> builder, string href = "#", bool active = false, bool disabled = false)
            where TConfig : BootstrapConfig
        {
            builder.AddChild(x => x.PageNum("&laquo;", href).SetActive(active).SetDisabled(disabled));
            return builder;
        }

        public static ComponentBuilder<TConfig, Pagination> AddNext<TConfig>(this ComponentBuilder<TConfig, Pagination> builder, string href = "#", bool active = false, bool disabled = false)
            where TConfig : BootstrapConfig
        {
            builder.AddChild(x => x.PageNum("&raquo;", href).SetActive(active).SetDisabled(disabled));
            return builder;
        }

        public static ComponentBuilder<TConfig, Pagination> AddPage<TConfig>(this ComponentBuilder<TConfig, Pagination> builder, string href = "#", bool active = false, bool disabled = false)
            where TConfig : BootstrapConfig
        {
            builder.AddChild(x => x.PageNum((++builder.Component.AutoPageNumber).ToString(), href).SetActive(active).SetDisabled(disabled));
            return builder;
        }
        
        // PageNum

        public static ComponentBuilder<TConfig, PageNum> PageNum<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text, string href = "#")
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<PageNum>
        {
            return new ComponentBuilder<TConfig, PageNum>(helper.Config, new PageNum(helper))
                .SetHref(href)
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, PageNum> SetActive<TConfig>(this ComponentBuilder<TConfig, PageNum> builder, bool active = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.Active = active;
            return builder;
        }

        public static ComponentBuilder<TConfig, PageNum> SetDisabled<TConfig>(this ComponentBuilder<TConfig, PageNum> builder, bool disabled = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.Disabled = disabled;
            return builder;
        }
    }
}
