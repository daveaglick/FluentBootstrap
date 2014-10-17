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

        public static Dropdown<TModel> Dropdown<TModel>(this IDropdownCreator<TModel> creator, string text = null)
        {
            return new Dropdown<TModel>(creator).SetText(text);
        }

        public static Dropdown<TModel> SetCaret<TModel>(this Dropdown<TModel> dropdown, bool caret = true)
        {
            dropdown.Caret = caret;
            return dropdown;
        }

        public static Dropdown<TModel> SetMenuRight<TModel>(this Dropdown<TModel> dropdown, bool menuRight = true)
        {
            dropdown.MenuRight = menuRight;
            return dropdown;
        }

        public static Dropdown<TModel> SetMenuLeft<TModel>(this Dropdown<TModel> dropdown, bool menuLeft = true)
        {
            dropdown.MenuLeft = menuLeft;
            return dropdown;
        }

        public static Dropdown<TModel> SetDropup<TModel>(this Dropdown<TModel> dropdown, bool dropup = true)
        {
            dropdown.ToggleCss(Css.Dropup, dropup);
            return dropdown;
        }

        // Dropdown items

        public static DropdownLink<TModel> DropdownLink<TModel>(this IDropdownLinkCreator<TModel> creator, string text, string href = "#")
        {
            return new DropdownLink<TModel>(creator).SetHref(href).SetText(text);
        }

        public static DropdownLink<TModel> DropdownLink<TModel>(this IDropdownLinkCreator<TModel> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return new DropdownLink<TModel>(creator).SetAction(actionName, controllerName, routeValues).SetText(text);
        }

        public static DropdownLink<TModel> SetDisabled<TModel>(this DropdownLink<TModel> dropdownLink, bool disabled = true)
        {
            dropdownLink.Disabled = disabled;
            return dropdownLink;
        }

        public static DropdownHeader<TModel> DropdownHeader<TModel>(this IDropdownHeaderCreator<TModel> creator, string text = null)
        {
            return new DropdownHeader<TModel>(creator).SetText(text);
        }

        public static DropdownDivider<TModel> DropdownDivider<TModel>(this IDropdownDividerCreator<TModel> creator)
        {
            return new DropdownDivider<TModel>(creator);
        }
    }
}
