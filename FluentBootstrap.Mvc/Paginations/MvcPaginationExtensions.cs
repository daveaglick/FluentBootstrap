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
        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Pagination> AddPrevious<TModel>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, Pagination> builder, string actionName, string controllerName, object routeValues = null, bool active = false, bool disabled = false)
        {
            builder.AddChild(x => x.PageNum("&laquo;", actionName, controllerName, routeValues).SetActive(active).SetDisabled(disabled));
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Pagination> AddNext<TModel>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, Pagination> builder, string actionName, string controllerName, object routeValues = null, bool active = false, bool disabled = false)
        {
            builder.AddChild(x => x.PageNum("&raquo;", actionName, controllerName, routeValues).SetActive(active).SetDisabled(disabled));
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Pagination> AddPage<TModel>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, Pagination> builder, string actionName, string controllerName, object routeValues = null, bool active = false, bool disabled = false)
        {
            builder.AddChild(x => x.PageNum((++builder.GetComponent().AutoPageNumber).ToString(), actionName, controllerName, routeValues).SetActive(active).SetDisabled(disabled));
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, PageNum> PageNum<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, string actionName, string controllerName, object routeValues = null)
            where TComponent : Component, ICanCreate<PageNum>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, PageNum>(helper.GetConfig(), helper.PageNum(text, null).GetComponent())
                .SetAction(actionName, controllerName, routeValues);
        }
    }
}
