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

        public static Link Link<TCreator>(this TCreator creator, string text, string href = "#")
            where TCreator : Link.ICreate
        {
            return new Link(creator.GetHelper()).Href(href).Text(text);
        }

        public static Link Link<TCreator>(this TCreator creator, string text, string actionName, string controllerName, object routeValues = null)
            where TCreator : Link.ICreate
        {
            return new Link(creator.GetHelper()).Action(actionName, controllerName, routeValues).Text(text);
        }

        // ILink
        
        public static TComponent Href<TComponent>(this TComponent component, string href)
            where TComponent : Tag, ILink
        {
            if (string.IsNullOrWhiteSpace(href))
            {
                href = "#";
            }
            component.MergeAttribute("href", href);
            return component;
        }

        public static TComponent Action<TComponent>(this TComponent component, string actionName, string controllerName, object routeValues = null)
            where TComponent : Tag, ILink
        {
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if (routeValueDictionary == null)
                new RouteValueDictionary(routeValues);

            return component.Href(UrlHelper.GenerateUrl(null, actionName, controllerName, routeValueDictionary,
                component.HtmlHelper.RouteCollection, component.ViewContext.RequestContext, true));
        }

        public static TComponent Route<TComponent>(this TComponent component, string routeName, object routeValues = null)
            where TComponent : Tag, ILink
        {
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if (routeValueDictionary == null)
                new RouteValueDictionary(routeValues);

            return component.Href(UrlHelper.GenerateUrl(routeName, null, null, routeValueDictionary,
                component.HtmlHelper.RouteCollection, component.ViewContext.RequestContext, false));
        }
    }
}
