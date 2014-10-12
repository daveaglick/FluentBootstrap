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
            return new Dropdown<TModel>(creator.GetHelper()).Text(text);
        }

        public static Dropdown<TModel> Caret<TModel>(this Dropdown<TModel> dropdown, bool caret = true)
        {
            dropdown.Caret = caret;
            return dropdown;
        }

        public static Dropdown<TModel> MenuRight<TModel>(this Dropdown<TModel> dropdown, bool menuRight = true)
        {
            dropdown.MenuRight = menuRight;
            return dropdown;
        }

        public static Dropdown<TModel> MenuLeft<TModel>(this Dropdown<TModel> dropdown, bool menuLeft = true)
        {
            dropdown.MenuLeft = menuLeft;
            return dropdown;
        }

        public static Dropdown<TModel> Dropup<TModel>(this Dropdown<TModel> dropdown, bool dropup = true)
        {
            dropdown.ToggleCss(Css.Dropup, dropup);
            return dropdown;
        }

        // Dropdown items

        public static DropdownLink<TModel> DropdownLink<TModel>(this IDropdownItemCreator<TModel> creator, string text, string href = "#")
        {
            return new DropdownLink<TModel>(creator.GetHelper()).Href(href).Text(text);
        }

        public static DropdownLink<TModel> DropdownLink<TModel>(this IDropdownItemCreator<TModel> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return new DropdownLink<TModel>(creator.GetHelper()).Action(actionName, controllerName, routeValues).Text(text);
        }

        public static DropdownLink<TModel> Disabled<TModel>(this DropdownLink<TModel> dropdownLink, bool disabled = true)
        {
            dropdownLink.Disabled = disabled;
            return dropdownLink;
        }

        public static DropdownHeader<TModel> DropdownHeader<TModel>(this IDropdownItemCreator<TModel> creator, string text = null)
        {
            return new DropdownHeader<TModel>(creator.GetHelper()).Text(text);
        }

        public static DropdownDivider<TModel> DropdownDivider<TModel>(this IDropdownItemCreator<TModel> creator)
        {
            return new DropdownDivider<TModel>(creator.GetHelper());
        }
    }
}
