using FluentBootstrap.Internals;
using FluentBootstrap.Mvc;
using FluentBootstrap.Thumbnails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class MvcThumbnailExtensions
    {
        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Thumbnail> Thumbnail<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string src, string actionName, string controllerName, object routeValues = null, string alt = null)
            where TComponent : Component, ICanCreate<Thumbnail>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, Thumbnail>(helper.GetConfig(), helper.Thumbnail(src, null, alt).GetComponent())
                .SetAction(actionName, controllerName, routeValues);
        }
    }
}
