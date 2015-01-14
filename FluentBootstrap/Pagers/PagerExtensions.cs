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

        public static Pager<TConfig> Pager<TConfig>(this IPagerCreator<TConfig> creator)
            where TConfig : BootstrapConfig
        {
            return new Pager<TConfig>(creator);
        }

        public static Pager<TConfig> AddPrevious<TConfig>(this Pager<TConfig> pager, string text, string href = "#", bool disabled = false)
            where TConfig : BootstrapConfig
        {
            pager.AddChild(pager.GetWrapper().Page(text, href).SetAlignment(PageAlignment.Previous).SetDisabled(disabled));
            return pager;
        }

        public static Pager<TConfig> AddNext<TConfig>(this Pager<TConfig> pager, string text, string href = "#", bool disabled = false)
            where TConfig : BootstrapConfig
        {
            pager.AddChild(pager.GetWrapper().Page(text, href).SetAlignment(PageAlignment.Next).SetDisabled(disabled));
            return pager;
        }

        public static Pager<TConfig> AddPage<TConfig>(this Pager<TConfig> pager, string text, string href = "#", bool disabled = false)
            where TConfig : BootstrapConfig
        {
            pager.AddChild(pager.GetWrapper().Page(text, href).SetDisabled(disabled));
            return pager;
        }
        
        // Page

        public static Page<TConfig> Page<TConfig>(this IPageCreator<TConfig> creator, string text, string href = "#")
            where TConfig : BootstrapConfig
        {
            return new Page<TConfig>(creator).SetHref(href).SetText(text);
        }

        public static Page<TConfig> SetDisabled<TConfig>(this Page<TConfig> pageNum, bool disabled = true)
            where TConfig : BootstrapConfig
        {
            pageNum.Disabled = disabled;
            return pageNum;
        }

        public static Page<TConfig> SetAlignment<TConfig>(this Page<TConfig> page, PageAlignment alignment)
            where TConfig : BootstrapConfig
        {
            page.Alignment = alignment;
            return page;
        }
    }
}
