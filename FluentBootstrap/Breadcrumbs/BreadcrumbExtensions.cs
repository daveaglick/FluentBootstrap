using FluentBootstrap.Breadcrumbs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class BreadcrumbExtensions
    {
        public static Breadcrumb<TModel> Breadcrumb<TModel>(this IBreadcrumbCreator<TModel> creator)
        {
            return new Breadcrumb<TModel>(creator);
        }

        public static Crumb<TModel> Crumb<TModel>(this ICrumbCreator<TModel> creator, string text, string href = "#")
        {
            return new Crumb<TModel>(creator).SetHref(href).SetText(text);
        }

        public static Crumb<TModel> Crumb<TModel>(this ICrumbCreator<TModel> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return new Crumb<TModel>(creator).SetAction(actionName, controllerName, routeValues).SetText(text);
        }

        public static Crumb<TModel> SetActive<TModel>(this Crumb<TModel> crumb, bool active = true)
        {
            crumb.Active = active;
            return crumb;
        }
    }
}
