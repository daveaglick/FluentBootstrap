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
        public static MediaObject<MvcBootstrapHelper<TModel>> MediaObject<TModel>(this IMediaObjectCreator<MvcBootstrapHelper<TModel>> creator, string src, string actionName, string controllerName, object routeValues = null, string alt = null)
        {
            return creator.MediaObject(src, null, alt).SetAction(actionName, controllerName, routeValues);
        }
    }
}
