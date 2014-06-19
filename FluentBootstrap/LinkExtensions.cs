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

        public static Link<TModel> Link<TModel>(this ILinkCreator<TModel> creator, string text, string href = "#")
        {
            return new Link<TModel>(creator.GetHelper()).Href(href).Text(text);
        }

        public static Link<TModel> Link<TModel>(this ILinkCreator<TModel> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return new Link<TModel>(creator.GetHelper()).Action(actionName, controllerName, routeValues).Text(text);
        }

        // IHasLinkExtensions
        
        public static TThis Href<TModel, TThis>(this Component<TModel, TThis> component, string href)
            where TThis : Tag<TModel, TThis>, IHasLinkExtensions
        {
            TThis tag = component.GetThis();
            if (string.IsNullOrWhiteSpace(href))
            {
                href = "#";
            }
            tag.MergeAttribute("href", href);
            return tag;
        }

        public static TThis Action<TModel, TThis>(this Component<TModel, TThis> component, string actionName, string controllerName, object routeValues = null)
            where TThis : Tag<TModel, TThis>, IHasLinkExtensions
        {
            TThis tag = component.GetThis();
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if (routeValueDictionary == null)
                new RouteValueDictionary(routeValues);

            return tag.Href<TModel, TThis>(UrlHelper.GenerateUrl(null, actionName, controllerName, routeValueDictionary,
                component.HtmlHelper.RouteCollection, component.ViewContext.RequestContext, true));
        }

        public static TThis Route<TModel, TThis>(this Component<TModel, TThis> component, string routeName, object routeValues = null)
            where TThis : Tag<TModel, TThis>, IHasLinkExtensions
        {
            TThis tag = component.GetThis();
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if (routeValueDictionary == null)
                new RouteValueDictionary(routeValues);

            return tag.Href<TModel, TThis>(UrlHelper.GenerateUrl(routeName, null, null, routeValueDictionary,
                component.HtmlHelper.RouteCollection, component.ViewContext.RequestContext, false));
        }
    }
}
