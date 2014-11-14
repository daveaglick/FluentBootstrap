using FluentBootstrap.Mvc;
using FluentBootstrap.Pagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class MvcPagerExtensions
    {
        public static Pager<MvcBootstrapHelper<TModel>> AddPrevious<TModel>(this Pager<MvcBootstrapHelper<TModel>> pager, string text, string actionName, string controllerName, object routeValues = null, bool disabled = false)
        {
            pager.AddChild(pager.GetWrapper().Page(text, actionName, controllerName, routeValues).SetAlignment(PageAlignment.Previous).SetDisabled(disabled));
            return pager;
        }

        public static Pager<MvcBootstrapHelper<TModel>> AddNext<TModel>(this Pager<MvcBootstrapHelper<TModel>> pager, string text, string actionName, string controllerName, object routeValues = null, bool disabled = false)
        {
            pager.AddChild(pager.GetWrapper().Page(text, actionName, controllerName, routeValues).SetAlignment(PageAlignment.Next).SetDisabled(disabled));
            return pager;
        }

        public static Pager<MvcBootstrapHelper<TModel>> AddPage<TModel>(this Pager<MvcBootstrapHelper<TModel>> pager, string text, string actionName, string controllerName, object routeValues = null, bool disabled = false)
        {
            pager.AddChild(pager.GetWrapper().Page(text, actionName, controllerName, routeValues).SetDisabled(disabled));
            return pager;
        }

        public static Page<MvcBootstrapHelper<TModel>> Page<TModel>(this IPageCreator<MvcBootstrapHelper<TModel>> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return creator.Page(text, null).SetAction(actionName, controllerName, routeValues);
        }
    }
}
