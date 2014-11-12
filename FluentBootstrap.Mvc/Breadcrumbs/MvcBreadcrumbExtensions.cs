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
        public static Crumb<THelper> Crumb<THelper>(this ICrumbCreator<THelper> creator, string text, string actionName, string controllerName, object routeValues = null)
            where THelper : MvcBootstrapHelper<THelper>, BootstrapHelper<THelper>
        {
            return creator.Crumb(text, null).SetAction(actionName, controllerName, routeValues).SetText(text);
        }
    }
}
