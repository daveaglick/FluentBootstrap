using FluentBootstrap.Internals;
using FluentBootstrap.Links;
using FluentBootstrap.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace FluentBootstrap
{
    public static class MvcLinkExtensions
    {
        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Link> Link<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, string actionName, string controllerName, object routeValues = null)
            where TComponent : Component, ICanCreate<Link>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, Link>(helper.GetConfig(), helper.Link(text, null).GetComponent())
                .SetAction(actionName, controllerName, routeValues)
                .SetText(text);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, TTag> SetAction<TTag, TModel>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, TTag> builder, string actionName, string controllerName, object routeValues = null)
            where TTag : Tag, IHasLinkExtensions
        {
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if (routeValueDictionary == null)
            {
                new RouteValueDictionary(routeValues);
            }
            builder.SetHref(UrlHelper.GenerateUrl(null, actionName, controllerName, routeValueDictionary,
                builder.GetConfig().HtmlHelper.RouteCollection, builder.GetConfig().HtmlHelper.ViewContext.RequestContext, true));
            return builder;
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, TTag> SetRoute<TTag, TModel>(
            this ComponentBuilder<MvcBootstrapConfig<TModel>, TTag> builder, string routeName, object routeValues = null)
            where TTag : Tag, IHasLinkExtensions
        {
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if (routeValueDictionary == null)
            {
                new RouteValueDictionary(routeValues);
            }
            builder.SetHref(UrlHelper.GenerateUrl(routeName, null, null, routeValueDictionary,
                builder.GetConfig().HtmlHelper.RouteCollection, builder.GetConfig().HtmlHelper.ViewContext.RequestContext, false));
            return builder;
        }
    }
}
