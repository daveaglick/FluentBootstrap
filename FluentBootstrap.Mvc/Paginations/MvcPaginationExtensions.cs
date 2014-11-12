using FluentBootstrap.Internals;
using FluentBootstrap.Mvc;
using FluentBootstrap.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class MvcPaginationExtensions
    {
        public static Pagination<MvcBootstrapHelper<TModel>> AddPrevious<TModel>(this Pagination<MvcBootstrapHelper<TModel>> pagination, string actionName, string controllerName, object routeValues = null, bool active = false, bool disabled = false)
        {
            pagination.AddChild(pagination.GetWrapper().PageNum("&laquo;", actionName, controllerName, routeValues).SetActive(active).SetDisabled(disabled));
            return pagination;
        }

        public static Pagination<MvcBootstrapHelper<TModel>> AddNext<TModel>(this Pagination<MvcBootstrapHelper<TModel>> pagination, string actionName, string controllerName, object routeValues = null, bool active = false, bool disabled = false)
        {
            pagination.AddChild(pagination.GetWrapper().PageNum("&raquo;", actionName, controllerName, routeValues).SetActive(active).SetDisabled(disabled));
            return pagination;
        }

        public static Pagination<MvcBootstrapHelper<TModel>> AddPage<TModel>(this Pagination<MvcBootstrapHelper<TModel>> pagination, string actionName, string controllerName, object routeValues = null, bool active = false, bool disabled = false)
        {
            pagination.AddChild(pagination.GetWrapper().PageNum((++pagination.AutoPageNumber).ToString(), actionName, controllerName, routeValues).SetActive(active).SetDisabled(disabled));
            return pagination;
        }

        public static PageNum<MvcBootstrapHelper<TModel>> PageNum<TModel>(this IPageNumCreator<MvcBootstrapHelper<TModel>> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return creator.PageNum(text, null).SetAction(actionName, controllerName, routeValues);
        }
    }
}
