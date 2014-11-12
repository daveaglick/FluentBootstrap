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
            where THelper : BootstrapHelper<THelper>
        {
            return new Dropdown<THelper>(creator).SetText(text);
        }

        public static Dropdown<THelper> SetCaret<THelper>(this Dropdown<THelper> dropdown, bool caret = true)
            where THelper : BootstrapHelper<THelper>
        {
            dropdown.Caret = caret;
            return dropdown;
        }

        public static Dropdown<THelper> SetMenuRight<THelper>(this Dropdown<THelper> dropdown, bool menuRight = true)
            where THelper : BootstrapHelper<THelper>
        {
            dropdown.MenuRight = menuRight;
            return dropdown;
        }

        public static Dropdown<THelper> SetMenuLeft<THelper>(this Dropdown<THelper> dropdown, bool menuLeft = true)
            where THelper : BootstrapHelper<THelper>
        {
            dropdown.MenuLeft = menuLeft;
            return dropdown;
        }

        public static Dropdown<THelper> SetDropup<THelper>(this Dropdown<THelper> dropdown, bool dropup = true)
            where THelper : BootstrapHelper<THelper>
        {
            dropdown.ToggleCss(Css.Dropup, dropup);
            return dropdown;
        }

        // Dropdown items

        public static DropdownLink<THelper> DropdownLink<THelper>(this IDropdownLinkCreator<THelper> creator, string text, string href = "#")
            where THelper : BootstrapHelper<THelper>
        {
            return new DropdownLink<THelper>(creator).SetHref(href).SetText(text);
        }

        public static DropdownLink<THelper> SetDisabled<THelper>(this DropdownLink<THelper> dropdownLink, bool disabled = true)
            where THelper : BootstrapHelper<THelper>
        {
            dropdownLink.Disabled = disabled;
            return dropdownLink;
        }

        public static DropdownHeader<THelper> DropdownHeader<THelper>(this IDropdownHeaderCreator<THelper> creator, string text = null)
            where THelper : BootstrapHelper<THelper>
        {
            return new DropdownHeader<THelper>(creator).SetText(text);
        }

        public static DropdownDivider<THelper> DropdownDivider<THelper>(this IDropdownDividerCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new DropdownDivider<THelper>(creator);
        }
    }
}
