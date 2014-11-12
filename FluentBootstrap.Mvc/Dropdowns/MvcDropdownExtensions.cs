using FluentBootstrap.Dropdowns;
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
        public static DropdownLink<MvcBootstrapHelper<TModel>> DropdownLink<TModel>(this IDropdownLinkCreator<MvcBootstrapHelper<TModel>> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return creator.DropdownLink(text, null).SetAction(actionName, controllerName, routeValues).SetText(text);
        }
    }
}
