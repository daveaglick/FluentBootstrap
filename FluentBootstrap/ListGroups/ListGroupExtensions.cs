using FluentBootstrap.ListGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class ListGroupExtensions
    {
        // ListGroup

        public static ListGroup<TModel> ListGroup<TModel>(this IListGroupCreator<TModel> creator)
        {
            return new ListGroup<TModel>(creator);
        }

        // ListGroupItem

        public static ListGroupItem<TModel> ListGroupItem<TModel>(this IListGroupItemCreator<TModel> creator, string text = null, string href = null)
        {
            return new ListGroupItem<TModel>(creator).SetText(text).SetHref(href);
        }

        public static ListGroupItem<TModel> ListGroupItem<TModel>(this IListGroupItemCreator<TModel> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return new ListGroupItem<TModel>(creator).SetText(text).SetAction(actionName, controllerName, routeValues);
        }

        public static ListGroupItem<TModel> SetActive<TModel>(this ListGroupItem<TModel> listGroupItem, bool active = true)
        {
            listGroupItem.Active = active;
            return listGroupItem;
        }

        public static ListGroupItem<TModel> SetDisabled<TModel>(this ListGroupItem<TModel> listGroupItem, bool disabled = true)
        {
            listGroupItem.Disabled = disabled;
            return listGroupItem;
        }

        public static ListGroupItem<TModel> SetHeading<TModel>(this ListGroupItem<TModel> listGroupItem, string heading)
        {
            listGroupItem.Heading = heading;
            return listGroupItem;
        }

        public static ListGroupItem<TModel> SetState<TModel>(this ListGroupItem<TModel> listGroupItem, ListGroupItemState state)
        {
            return listGroupItem.ToggleCss(state);
        }
    }
}
