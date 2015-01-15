using FluentBootstrap.Internals;
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
        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Pager> AddPrevious<TModel>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, Pager> builder, string text, string actionName, string controllerName, object routeValues = null, bool disabled = false)
        {
            builder.AddChild(x => x.Page(text, actionName, controllerName, routeValues).SetAlignment(PageAlignment.Previous).SetDisabled(disabled));
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Pager> AddNext<TModel>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, Pager> builder, string text, string actionName, string controllerName, object routeValues = null, bool disabled = false)
        {
            builder.AddChild(x => x.Page(text, actionName, controllerName, routeValues).SetAlignment(PageAlignment.Next).SetDisabled(disabled));
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Pager> AddPage<TModel>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, Pager> builder, string text, string actionName, string controllerName, object routeValues = null, bool disabled = false)
        {
            builder.AddChild(x => x.Page(text, actionName, controllerName, routeValues).SetDisabled(disabled));
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Page> Page<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, string actionName, string controllerName, object routeValues = null)
            where TComponent : Component, ICanCreate<Page>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, Page>(helper.GetConfig(), helper.Page(text, null).GetComponent())
                .SetAction(actionName, controllerName, routeValues);
        }
    }
}
