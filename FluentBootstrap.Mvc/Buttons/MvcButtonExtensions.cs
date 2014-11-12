using FluentBootstrap.Buttons;
using FluentBootstrap.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class MvcButtonExtensions
    {
        public static LinkButton<MvcBootstrapHelper<TModel>> LinkButton<TModel>(this ILinkButtonCreator<MvcBootstrapHelper<TModel>> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return creator.LinkButton(text, null).SetAction(actionName, controllerName, routeValues);
        }
    }
}
