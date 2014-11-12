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
        {
            return new Pager<THelper>(creator);
        }

        public static Pager<THelper> AddPrevious<THelper>(this Pager<THelper> pager, string text, string href = "#", bool disabled = false)
        {
            pager.AddChild(pager.GetWrapper().Page(text, href).SetAlignment(PageAlignment.Previous).SetDisabled(disabled));
            return pager;
        }

        public static Pager<THelper> AddPrevious<THelper>(this Pager<THelper> pager, string text, string actionName, string controllerName, object routeValues = null, bool disabled = false)
        {
            pager.AddChild(pager.GetWrapper().Page(text, actionName, controllerName, routeValues).SetAlignment(PageAlignment.Previous).SetDisabled(disabled));
            return pager;
        }

        public static Pager<THelper> AddNext<THelper>(this Pager<THelper> pager, string text, string href = "#", bool disabled = false)
        {
            pager.AddChild(pager.GetWrapper().Page(text, href).SetAlignment(PageAlignment.Next).SetDisabled(disabled));
            return pager;
        }

        public static Pager<THelper> AddNext<THelper>(this Pager<THelper> pager, string text, string actionName, string controllerName, object routeValues = null, bool disabled = false)
        {
            pager.AddChild(pager.GetWrapper().Page(text, actionName, controllerName, routeValues).SetAlignment(PageAlignment.Next).SetDisabled(disabled));
            return pager;
        }

        public static Pager<THelper> AddPage<THelper>(this Pager<THelper> pager, string text, string href = "#", bool disabled = false)
        {
            pager.AddChild(pager.GetWrapper().Page(text, href).SetDisabled(disabled));
            return pager;
        }

        public static Pager<THelper> AddPage<THelper>(this Pager<THelper> pager, string text, string actionName, string controllerName, object routeValues = null, bool disabled = false)
        {
            pager.AddChild(pager.GetWrapper().Page(text, actionName, controllerName, routeValues).SetDisabled(disabled));
            return pager;
        }

        // Page

        public static Page<THelper> Page<THelper>(this IPageCreator<THelper> creator, string text, string href = "#")
        {
            return new Page<THelper>(creator).SetHref(href).SetText(text);
        }

        public static Page<THelper> Page<THelper>(this IPageCreator<THelper> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return new Page<THelper>(creator).SetAction(actionName, controllerName, routeValues).SetText(text);
        }

        public static Page<THelper> SetDisabled<THelper>(this Page<THelper> pageNum, bool disabled = true)
        {
            pageNum.Disabled = disabled;
            return pageNum;
        }

        public static Page<THelper> SetAlignment<THelper>(this Page<THelper> page, PageAlignment alignment)
        {
            page.Alignment = alignment;
            return page;
        }
    }
}
