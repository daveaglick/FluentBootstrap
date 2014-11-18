using FluentBootstrap.Breadcrumbs;
using FluentBootstrap.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class MvcBreadcrumbExtensions
    {
        public static Crumb<MvcBootstrapHelper<TModel>> Crumb<TModel>(this ICrumbCreator<MvcBootstrapHelper<TModel>> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return creator.Crumb(text, null).SetAction(actionName, controllerName, routeValues).SetText(text);
        }
    }
}
