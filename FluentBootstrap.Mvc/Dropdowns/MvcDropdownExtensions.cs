using FluentBootstrap.Dropdowns;
using FluentBootstrap.Internals;
using FluentBootstrap.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class MvcDropdownExtensions
    {
        public static ComponentBuilder<MvcBootstrapConfig<TModel>, DropdownLink> DropdownLink<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, string actionName, string controllerName, object routeValues = null)
            where TComponent : Component, ICanCreate<DropdownLink>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, DropdownLink>(helper.GetConfig(), helper.DropdownLink(text, null).GetComponent())
                .SetAction(actionName, controllerName, routeValues)
                .SetText(text);
        }
    }
}
