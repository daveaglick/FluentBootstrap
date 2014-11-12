using FluentBootstrap.Dropdowns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class DropdownExtensions
    {
        // Dropdown

        public static Dropdown<THelper> Dropdown<THelper>(this IDropdownCreator<THelper> creator, string text = null)
        {
            return new Dropdown<THelper>(creator).SetText(text);
        }

        public static Dropdown<THelper> SetCaret<THelper>(this Dropdown<THelper> dropdown, bool caret = true)
        {
            dropdown.Caret = caret;
            return dropdown;
        }

        public static Dropdown<THelper> SetMenuRight<THelper>(this Dropdown<THelper> dropdown, bool menuRight = true)
        {
            dropdown.MenuRight = menuRight;
            return dropdown;
        }

        public static Dropdown<THelper> SetMenuLeft<THelper>(this Dropdown<THelper> dropdown, bool menuLeft = true)
        {
            dropdown.MenuLeft = menuLeft;
            return dropdown;
        }

        public static Dropdown<THelper> SetDropup<THelper>(this Dropdown<THelper> dropdown, bool dropup = true)
        {
            dropdown.ToggleCss(Css.Dropup, dropup);
            return dropdown;
        }

        // Dropdown items

        public static DropdownLink<THelper> DropdownLink<THelper>(this IDropdownLinkCreator<THelper> creator, string text, string href = "#")
        {
            return new DropdownLink<THelper>(creator).SetHref(href).SetText(text);
        }

        public static DropdownLink<THelper> DropdownLink<THelper>(this IDropdownLinkCreator<THelper> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return new DropdownLink<THelper>(creator).SetAction(actionName, controllerName, routeValues).SetText(text);
        }

        public static DropdownLink<THelper> SetDisabled<THelper>(this DropdownLink<THelper> dropdownLink, bool disabled = true)
        {
            dropdownLink.Disabled = disabled;
            return dropdownLink;
        }

        public static DropdownHeader<THelper> DropdownHeader<THelper>(this IDropdownHeaderCreator<THelper> creator, string text = null)
        {
            return new DropdownHeader<THelper>(creator).SetText(text);
        }

        public static DropdownDivider<THelper> DropdownDivider<THelper>(this IDropdownDividerCreator<THelper> creator)
        {
            return new DropdownDivider<THelper>(creator);
        }
    }
}
