using FluentBootstrap.Internals;
using FluentBootstrap.ListGroups;
using FluentBootstrap.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class MvcListGroupExtensions
    {
        public static ComponentBuilder<MvcBootstrapConfig<TModel>, ListGroupItem> ListGroupItem<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, string actionName, string controllerName, object routeValues = null)
            where TComponent : Component, ICanCreate<ListGroupItem>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, ListGroupItem>(helper.GetConfig(), helper.ListGroupItem(text, null).GetComponent())
                .SetAction(actionName, controllerName, routeValues);
        }
    }
}
