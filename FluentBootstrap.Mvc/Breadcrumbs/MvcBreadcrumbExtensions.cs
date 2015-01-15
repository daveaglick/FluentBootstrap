using FluentBootstrap.Breadcrumbs;
using FluentBootstrap.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentBootstrap.Internals;

namespace FluentBootstrap
{
    public static class MvcBreadcrumbExtensions
    {
        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Crumb> Crumb<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, string actionName, string controllerName, object routeValues = null)
            where TComponent : Component, ICanCreate<Crumb>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, Crumb>(helper.GetConfig(), helper.Crumb(text, null).GetComponent())
                .SetAction(actionName, controllerName, routeValues)
                .SetText(text);
        }
    }
}
