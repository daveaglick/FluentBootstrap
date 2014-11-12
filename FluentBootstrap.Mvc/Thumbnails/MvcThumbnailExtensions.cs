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
        public static Thumbnail<MvcBootstrapHelper<TModel>> Thumbnail<TModel>(this IThumbnailCreator<MvcBootstrapHelper<TModel>> creator, string src, string actionName, string controllerName, object routeValues = null, string alt = null)
        {
            return creator.Thumbnail(src, null, alt).SetAction(actionName, controllerName, routeValues);
        }
    }
}
