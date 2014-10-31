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
            return new Link<TModel>(creator).SetHref(href).SetText(text);
        }

        public static Link<TModel> Link<TModel>(this ILinkCreator<TModel> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return new Link<TModel>(creator).SetAction(actionName, controllerName, routeValues).SetText(text);
        }

        // IHasLinkExtensions
        
        public static TThis SetHref<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, string href)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasLinkExtensions
            where TWrapper : TagWrapper<TModel>, new()
        {
            if (string.IsNullOrWhiteSpace(href))
            {
                return component.GetThis();
            }
            return component.GetThis().MergeAttribute("href", href);
        }

        public static TThis SetAction<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, string actionName, string controllerName, object routeValues = null)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasLinkExtensions
            where TWrapper : TagWrapper<TModel>, new()
        {
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if (routeValueDictionary == null)
            {
                new RouteValueDictionary(routeValues);
            }
            return component.GetThis().SetHref(UrlHelper.GenerateUrl(null, actionName, controllerName, routeValueDictionary,
                component.HtmlHelper.RouteCollection, component.ViewContext.RequestContext, true));
        }

        public static TThis SetRoute<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, string routeName, object routeValues = null)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasLinkExtensions
            where TWrapper : TagWrapper<TModel>, new()
        {
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if (routeValueDictionary == null)
            {
                new RouteValueDictionary(routeValues);
            }
            return component.GetThis().SetHref(UrlHelper.GenerateUrl(routeName, null, null, routeValueDictionary,
                component.HtmlHelper.RouteCollection, component.ViewContext.RequestContext, false));
        }
    }
}
