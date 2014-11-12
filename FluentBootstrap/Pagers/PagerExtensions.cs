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

        public static Pager<THelper> Pager<THelper>(this IPagerCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new Pager<THelper>(creator);
        }

        public static Pager<THelper> AddPrevious<THelper>(this Pager<THelper> pager, string text, string href = "#", bool disabled = false)
            where THelper : BootstrapHelper<THelper>
        {
            pager.AddChild(pager.GetWrapper().Page(text, href).SetAlignment(PageAlignment.Previous).SetDisabled(disabled));
            return pager;
        }

        public static Pager<THelper> AddNext<THelper>(this Pager<THelper> pager, string text, string href = "#", bool disabled = false)
            where THelper : BootstrapHelper<THelper>
        {
            pager.AddChild(pager.GetWrapper().Page(text, href).SetAlignment(PageAlignment.Next).SetDisabled(disabled));
            return pager;
        }

        public static Pager<THelper> AddPage<THelper>(this Pager<THelper> pager, string text, string href = "#", bool disabled = false)
            where THelper : BootstrapHelper<THelper>
        {
            pager.AddChild(pager.GetWrapper().Page(text, href).SetDisabled(disabled));
            return pager;
        }
        
        // Page

        public static Page<THelper> Page<THelper>(this IPageCreator<THelper> creator, string text, string href = "#")
            where THelper : BootstrapHelper<THelper>
        {
            return new Page<THelper>(creator).SetHref(href).SetText(text);
        }

        public static Page<THelper> SetDisabled<THelper>(this Page<THelper> pageNum, bool disabled = true)
            where THelper : BootstrapHelper<THelper>
        {
            pageNum.Disabled = disabled;
            return pageNum;
        }

        public static Page<THelper> SetAlignment<THelper>(this Page<THelper> page, PageAlignment alignment)
            where THelper : BootstrapHelper<THelper>
        {
            page.Alignment = alignment;
            return page;
        }
    }
}
