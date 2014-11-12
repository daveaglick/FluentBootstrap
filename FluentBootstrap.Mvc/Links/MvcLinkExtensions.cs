using FluentBootstrap.Links;
using FluentBootstrap.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using FluentBootstrap.Internals;

namespace FluentBootstrap
{
    public static class MvcLinkExtensions
    {
        public static Link<MvcBootstrapHelper<TModel>> Link<TModel>(this ILinkCreator<MvcBootstrapHelper<TModel>> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return creator.Link(text, null).SetAction(actionName, controllerName, routeValues).SetText(text);
        }

        public static TThis SetAction<TModel, TThis, TWrapper>(this Component<MvcBootstrapHelper<TModel>, TThis, TWrapper> component, string actionName, string controllerName, object routeValues = null)
            where TThis : Tag<MvcBootstrapHelper<TModel>, TThis, TWrapper>, IHasLinkExtensions
            where TWrapper : TagWrapper<MvcBootstrapHelper<TModel>>, new()
        {
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if (routeValueDictionary == null)
            {
                new RouteValueDictionary(routeValues);
            }
            return component.GetThis().SetHref(UrlHelper.GenerateUrl(null, actionName, controllerName, routeValueDictionary,
                component.GetHelper().HtmlHelper.RouteCollection, component.GetHelper().HtmlHelper.ViewContext.RequestContext, true));
        }

        public static TThis SetRoute<TModel, TThis, TWrapper>(this Component<MvcBootstrapHelper<TModel>, TThis, TWrapper> component, string routeName, object routeValues = null)
            where TThis : Tag<MvcBootstrapHelper<TModel>, TThis, TWrapper>, IHasLinkExtensions
            where TWrapper : TagWrapper<MvcBootstrapHelper<TModel>>, new()
        {
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if (routeValueDictionary == null)
            {
                new RouteValueDictionary(routeValues);
            }
            return component.GetThis().SetHref(UrlHelper.GenerateUrl(routeName, null, null, routeValueDictionary,
                component.GetHelper().HtmlHelper.RouteCollection, component.GetHelper().HtmlHelper.ViewContext.RequestContext, false));
        }
    }
}
