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
        public static LinkButton<THelper> LinkButton<THelper>(this ILinkButtonCreator<THelper> creator, string text, string actionName, string controllerName, object routeValues = null)
            where THelper : MvcBootstrapHelper<THelper>, BootstrapHelper<THelper>
        {
            return creator.LinkButton(text, null).SetAction(actionName, controllerName, routeValues);
        }
    }
}
