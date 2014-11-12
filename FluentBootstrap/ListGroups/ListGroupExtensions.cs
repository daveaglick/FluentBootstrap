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

        public static ListGroup<THelper> ListGroup<THelper>(this IListGroupCreator<THelper> creator)
        {
            return new ListGroup<THelper>(creator);
        }

        // ListGroupItem

        public static ListGroupItem<THelper> ListGroupItem<THelper>(this IListGroupItemCreator<THelper> creator, string text = null, string href = null)
        {
            return new ListGroupItem<THelper>(creator).SetText(text).SetHref(href);
        }

        public static ListGroupItem<THelper> ListGroupItem<THelper>(this IListGroupItemCreator<THelper> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return new ListGroupItem<THelper>(creator).SetText(text).SetAction(actionName, controllerName, routeValues);
        }

        public static ListGroupItem<THelper> SetActive<THelper>(this ListGroupItem<THelper> listGroupItem, bool active = true)
        {
            listGroupItem.Active = active;
            return listGroupItem;
        }

        public static ListGroupItem<THelper> SetDisabled<THelper>(this ListGroupItem<THelper> listGroupItem, bool disabled = true)
        {
            listGroupItem.Disabled = disabled;
            return listGroupItem;
        }

        public static ListGroupItem<THelper> SetHeading<THelper>(this ListGroupItem<THelper> listGroupItem, string heading)
        {
            listGroupItem.Heading = heading;
            return listGroupItem;
        }

        public static ListGroupItem<THelper> SetState<THelper>(this ListGroupItem<THelper> listGroupItem, ListGroupItemState state)
        {
            return listGroupItem.ToggleCss(state);
        }
    }
}
