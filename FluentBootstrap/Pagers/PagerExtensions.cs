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

        public static Pager<TModel> Pager<TModel>(this IPagerCreator<TModel> creator)
        {
            return new Pager<TModel>(creator);
        }

        public static Pager<TModel> AddPrevious<TModel>(this Pager<TModel> pager, string text, string href = "#", bool disabled = false)
        {
            pager.AddChild(pager.GetWrapper().Page(text, href).SetAlignment(PageAlignment.Previous).SetDisabled(disabled));
            return pager;
        }

        public static Pager<TModel> AddPrevious<TModel>(this Pager<TModel> pager, string text, string actionName, string controllerName, object routeValues = null, bool disabled = false)
        {
            pager.AddChild(pager.GetWrapper().Page(text, actionName, controllerName, routeValues).SetAlignment(PageAlignment.Previous).SetDisabled(disabled));
            return pager;
        }

        public static Pager<TModel> AddNext<TModel>(this Pager<TModel> pager, string text, string href = "#", bool disabled = false)
        {
            pager.AddChild(pager.GetWrapper().Page(text, href).SetAlignment(PageAlignment.Next).SetDisabled(disabled));
            return pager;
        }

        public static Pager<TModel> AddNext<TModel>(this Pager<TModel> pager, string text, string actionName, string controllerName, object routeValues = null, bool disabled = false)
        {
            pager.AddChild(pager.GetWrapper().Page(text, actionName, controllerName, routeValues).SetAlignment(PageAlignment.Next).SetDisabled(disabled));
            return pager;
        }

        public static Pager<TModel> AddPage<TModel>(this Pager<TModel> pager, string text, string href = "#", bool disabled = false)
        {
            pager.AddChild(pager.GetWrapper().Page(text, href).SetDisabled(disabled));
            return pager;
        }

        public static Pager<TModel> AddPage<TModel>(this Pager<TModel> pager, string text, string actionName, string controllerName, object routeValues = null, bool disabled = false)
        {
            pager.AddChild(pager.GetWrapper().Page(text, actionName, controllerName, routeValues).SetDisabled(disabled));
            return pager;
        }

        // Page

        public static Page<TModel> Page<TModel>(this IPageCreator<TModel> creator, string text, string href = "#")
        {
            return new Page<TModel>(creator).SetHref(href).SetText(text);
        }

        public static Page<TModel> Page<TModel>(this IPageCreator<TModel> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return new Page<TModel>(creator).SetAction(actionName, controllerName, routeValues).SetText(text);
        }

        public static Page<TModel> SetDisabled<TModel>(this Page<TModel> pageNum, bool disabled = true)
        {
            pageNum.Disabled = disabled;
            return pageNum;
        }

        public static Page<TModel> SetAlignment<TModel>(this Page<TModel> page, PageAlignment alignment)
        {
            page.Alignment = alignment;
            return page;
        }
    }
}
