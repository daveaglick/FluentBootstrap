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
        public static MediaObject<THelper> MediaObject<THelper>(this IMediaObjectCreator<THelper> creator, string src, string actionName, string controllerName, object routeValues = null, string alt = null)
            where THelper : MvcBootstrapHelper<THelper>, BootstrapHelper<THelper>
        {
            return creator.MediaObject(src, null, alt).SetAction(actionName, controllerName, routeValues);
        }
    }
}
