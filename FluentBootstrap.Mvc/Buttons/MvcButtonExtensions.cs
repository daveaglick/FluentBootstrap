using FluentBootstrap.Buttons;
using FluentBootstrap.Internals;
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
        public static ComponentBuilder<MvcBootstrapConfig<TModel>, LinkButton> LinkButton<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, string actionName, string controllerName, object routeValues = null) 
            where TComponent : Component, ICanCreate<LinkButton>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, LinkButton>(helper.GetConfig(), helper.LinkButton(text, null).GetComponent())
                .SetAction(actionName, controllerName, routeValues);
        }
    }
}
