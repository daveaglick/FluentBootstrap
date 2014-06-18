using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentBootstrap.Links;
using System.Web.Mvc;
using System.Web.Routing;

namespace FluentBootstrap
{
    public static class LinkExtensions
    {
        // Link

        public static Link<TModel> Link<TModel>(this Link<TModel>.ICreate creator, string text, string href = "#")
        {
            return new Link<TModel>(creator.GetHelper()).Href<Link<TModel>, TModel>(href).Text<Link<TModel>, TModel>(text);
        }

        public static Link<TModel> Link<TModel>(this Link<TModel>.ICreate creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return new Link<TModel>(creator.GetHelper()).Action<Link<TModel>, TModel>(actionName, controllerName, routeValues).Text<Link<TModel>, TModel>(text);
        }

        // ILink
        
        public static TComponent Href<TComponent, TModel>(this TComponent component, string href)
            where TComponent : Tag<TModel>, ILink
        {
            if (string.IsNullOrWhiteSpace(href))
            {
                href = "#";
            }
            component.MergeAttribute("href", href);
            return component;
        }

        public static TComponent Action<TComponent, TModel>(this TComponent component, string actionName, string controllerName, object routeValues = null)
            where TComponent : Tag<TModel>, ILink
        {
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if (routeValueDictionary == null)
                new RouteValueDictionary(routeValues);

            return component.Href<TComponent, TModel>(UrlHelper.GenerateUrl(null, actionName, controllerName, routeValueDictionary,
                component.HtmlHelper.RouteCollection, component.ViewContext.RequestContext, true));
        }

        public static TComponent Route<TComponent, TModel>(this TComponent component, string routeName, object routeValues = null)
            where TComponent : Tag<TModel>, ILink
        {
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if (routeValueDictionary == null)
                new RouteValueDictionary(routeValues);

            return component.Href<TComponent, TModel>(UrlHelper.GenerateUrl(routeName, null, null, routeValueDictionary,
                component.HtmlHelper.RouteCollection, component.ViewContext.RequestContext, false));
        }
    }
}
