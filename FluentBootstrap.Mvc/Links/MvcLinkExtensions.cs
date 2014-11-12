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
        public static Link<THelper> Link<THelper>(this ILinkCreator<THelper> creator, string text, string actionName, string controllerName, object routeValues = null)
            where THelper : MvcBootstrapHelper<THelper>, BootstrapHelper<THelper>
        {
            return creator.Link(text, null).SetAction(actionName, controllerName, routeValues).SetText(text);
        }

        public static TThis SetAction<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, string actionName, string controllerName, object routeValues = null)
            where THelper : MvcBootstrapHelper<THelper>, BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasLinkExtensions
            where TWrapper : TagWrapper<THelper>, new()
        {
            RouteValueDictionary routeValueDictionary = routeValues == null ? new RouteValueDictionary() : routeValues as RouteValueDictionary;
            if (routeValueDictionary == null)
            {
                new RouteValueDictionary(routeValues);
            }
            return component.GetThis().SetHref(UrlHelper.GenerateUrl(null, actionName, controllerName, routeValueDictionary,
                component.GetHelper().HtmlHelper.RouteCollection, component.GetHelper().HtmlHelper.ViewContext.RequestContext, true));
        }

        public static TThis SetRoute<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, string routeName, object routeValues = null)
            where THelper : MvcBootstrapHelper<THelper>, BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasLinkExtensions
            where TWrapper : TagWrapper<THelper>, new()
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
