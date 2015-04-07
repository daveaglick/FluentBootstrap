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

        public static ComponentBuilder<TConfig, Dropdown> Dropdown<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Dropdown>
        {
            return new ComponentBuilder<TConfig, Dropdown>(helper.Config, new Dropdown(helper))
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, Dropdown> SetCaret<TConfig>(this ComponentBuilder<TConfig, Dropdown> builder, bool caret = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.Caret = caret;
            return builder;
        }

        public static ComponentBuilder<TConfig, Dropdown> SetMenuRight<TConfig>(this ComponentBuilder<TConfig, Dropdown> builder, bool menuRight = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.MenuRight = menuRight;
            return builder;
        }

        public static ComponentBuilder<TConfig, Dropdown> SetMenuLeft<TConfig>(this ComponentBuilder<TConfig, Dropdown> builder, bool menuLeft = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.MenuLeft = menuLeft;
            return builder;
        }

        public static ComponentBuilder<TConfig, Dropdown> SetDropup<TConfig>(this ComponentBuilder<TConfig, Dropdown> builder, bool dropup = true)
            where TConfig : BootstrapConfig
        {
            if (dropup)
            {
                builder.Component.ToggleCss(Css.Dropup, true, Css.Dropdown);
            }
            else
            {
                builder.Component.ToggleCss(Css.Dropdown, false, Css.Dropup);
            }
            return builder;
        }

        // Dropdown items

        public static ComponentBuilder<TConfig, DropdownLink> DropdownLink<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text, string href = "#")
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<DropdownLink>
        {
            return new ComponentBuilder<TConfig, DropdownLink>(helper.Config, new DropdownLink(helper))
                .SetHref(href)
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, DropdownLink> SetDisabled<TConfig>(this ComponentBuilder<TConfig, DropdownLink> dropdownLink, bool disabled = true)
            where TConfig : BootstrapConfig
        {
            dropdownLink.Component.Disabled = disabled;
            return dropdownLink;
        }

        public static ComponentBuilder<TConfig, DropdownLink> SetActive<TConfig>(this ComponentBuilder<TConfig, DropdownLink> dropdownLink, bool active = true)
            where TConfig : BootstrapConfig
        {
            dropdownLink.Component.Active = active;
            return dropdownLink;
        }

        public static ComponentBuilder<TConfig, DropdownHeader> DropdownHeader<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<DropdownHeader>
        {
            return new ComponentBuilder<TConfig, DropdownHeader>(helper.Config, new DropdownHeader(helper))
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, DropdownDivider> DropdownDivider<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TComponent : Component, ICanCreate<DropdownDivider>
            where TConfig : BootstrapConfig
        {
            return new ComponentBuilder<TConfig, DropdownDivider>(helper.Config, new DropdownDivider(helper));
        }
    }
}
