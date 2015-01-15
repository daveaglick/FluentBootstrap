using FluentBootstrap.Internals;
using FluentBootstrap.MediaObjects;
using FluentBootstrap.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class MvcMediaObjectExtensions
    {
        public static ComponentBuilder<MvcBootstrapConfig<TModel>, MediaObject> MediaObject<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string src, string actionName, string controllerName, object routeValues = null, string alt = null)
            where TComponent : Component, ICanCreate<MediaObject>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, MediaObject>(helper.GetConfig(), helper.MediaObject(src, null, alt).GetComponent())
                .SetAction(actionName, controllerName, routeValues);
        }
    }
}
