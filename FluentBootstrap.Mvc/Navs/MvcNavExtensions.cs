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
        public static Pill<MvcBootstrapHelper<TModel>> Pill<TModel>(this IPillCreator<MvcBootstrapHelper<TModel>> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return creator.Pill(text, null).SetAction(actionName, controllerName, routeValues);
        }

        public static Tab<MvcBootstrapHelper<TModel>> Tab<TModel>(this ITabCreator<MvcBootstrapHelper<TModel>> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return creator.Tab(text, null).SetAction(actionName, controllerName, routeValues);
        }
    }
}
