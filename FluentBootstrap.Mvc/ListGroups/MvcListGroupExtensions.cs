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
        public static ListGroupItem<MvcBootstrapHelper<TModel>> ListGroupItem<TModel>(this IListGroupItemCreator<MvcBootstrapHelper<TModel>> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return creator.ListGroupItem(text, null).SetAction(actionName, controllerName, routeValues);
        }
    }
}
