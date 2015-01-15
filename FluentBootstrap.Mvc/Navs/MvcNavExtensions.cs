using FluentBootstrap.Internals;
using FluentBootstrap.Mvc;
using FluentBootstrap.Navs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class MvcNavExtensions
    {
        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Pill> Pill<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, string actionName, string controllerName, object routeValues = null)
            where TComponent : Component, ICanCreate<Pill>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, Pill>(helper.GetConfig(), helper.Pill(text, null).GetComponent())
                .SetAction(actionName, controllerName, routeValues);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Tab> Tab<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, string actionName, string controllerName, object routeValues = null)
            where TComponent : Component, ICanCreate<Tab>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, Tab>(helper.GetConfig(), helper.Tab(text, null).GetComponent())
                .SetAction(actionName, controllerName, routeValues);
        }
    }
}
