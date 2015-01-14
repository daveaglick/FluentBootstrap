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

        public static ListGroup<TConfig> ListGroup<TConfig>(this IListGroupCreator<TConfig> creator)
            where TConfig : BootstrapConfig
        {
            return new ListGroup<TConfig>(creator);
        }

        // ListGroupItem

        public static ListGroupItem<TConfig> ListGroupItem<TConfig>(this IListGroupItemCreator<TConfig> creator, string text = null, string href = null)
            where TConfig : BootstrapConfig
        {
            return new ListGroupItem<TConfig>(creator).SetText(text).SetHref(href);
        }

        public static ListGroupItem<TConfig> SetActive<TConfig>(this ListGroupItem<TConfig> listGroupItem, bool active = true)
            where TConfig : BootstrapConfig
        {
            listGroupItem.Active = active;
            return listGroupItem;
        }

        public static ListGroupItem<TConfig> SetDisabled<TConfig>(this ListGroupItem<TConfig> listGroupItem, bool disabled = true)
            where TConfig : BootstrapConfig
        {
            listGroupItem.Disabled = disabled;
            return listGroupItem;
        }

        public static ListGroupItem<TConfig> SetHeading<TConfig>(this ListGroupItem<TConfig> listGroupItem, string heading)
            where TConfig : BootstrapConfig
        {
            listGroupItem.Heading = heading;
            return listGroupItem;
        }

        public static ListGroupItem<TConfig> SetState<TConfig>(this ListGroupItem<TConfig> listGroupItem, ListGroupItemState state)
            where TConfig : BootstrapConfig
        {
            return listGroupItem.ToggleCss(state);
        }
    }
}
