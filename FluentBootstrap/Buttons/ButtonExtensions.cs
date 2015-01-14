using FluentBootstrap.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class ButtonExtensions
    {
        // Button

        public static ComponentBuilder<TConfig, Button> Button<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null, ButtonType buttonType = ButtonType.Button, object value = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Button>
        {
            return new ComponentBuilder<TConfig, Button>(helper.Config, new Button(helper, buttonType))
                .SetText(text)
                .SetValue(value);
        }
        
        // Button groups

        public static ComponentBuilder<TConfig, ButtonGroup> ButtonGroup<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<ButtonGroup>
        {
            return new ComponentBuilder<TConfig, ButtonGroup>(helper.Config, new ButtonGroup(helper));
        }

        public static ComponentBuilder<TConfig, ButtonGroup> SetSize<TConfig>(this ComponentBuilder<TConfig, ButtonGroup> builder, ButtonGroupSize size)
            where TConfig : BootstrapConfig
        {
            builder.Component.ToggleCss(size);
            return builder;
        }

        public static ComponentBuilder<TConfig, ButtonGroup> SetVertical<TConfig>(this ComponentBuilder<TConfig, ButtonGroup> builder, bool vertical = true)
            where TConfig : BootstrapConfig
        {
            if (vertical)
            {
                builder.Component.ToggleCss(Css.BtnGroupVertical, true, Css.BtnGroup);
            }
            else
            {
                builder.Component.ToggleCss(Css.BtnGroup, true, Css.BtnGroupVertical);
            }
            return builder;
        }

        public static ComponentBuilder<TConfig, ButtonGroup> SetJustified<TConfig>(this ComponentBuilder<TConfig, ButtonGroup> builder, bool justified = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.ToggleCss(Css.BtnGroupJustified, justified);
            return builder;
        }

        // Button toolbar

        public static ComponentBuilder<TConfig, ButtonToolbar> ButtonToolbar<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<ButtonToolbar>
        {
            return new ComponentBuilder<TConfig, ButtonToolbar>(helper.Config, new ButtonToolbar(helper));
        }

        // Dropdown buttons

        public static ComponentBuilder<TConfig, DropdownButton> DropdownButton<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<DropdownButton>
        {
            return new ComponentBuilder<TConfig, DropdownButton>(helper.Config, new DropdownButton(helper));
        }

        public static ComponentBuilder<TConfig, DropdownButton> SetDropup<TConfig>(this ComponentBuilder<TConfig, DropdownButton> builder, bool dropup = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.ToggleCss(Css.Dropup, dropup);
            return builder;
        }

        // LinkButton

        public static ComponentBuilder<TConfig, LinkButton> LinkButton<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text, string href = "#")
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<LinkButton>
        {
            return new ComponentBuilder<TConfig, LinkButton>(helper.Config, new LinkButton(helper))
                .SetText(text)
                .SetHref(href);
        }

        public static ComponentBuilder<TConfig, LinkButton> SetDisabled<TConfig>(this ComponentBuilder<TConfig, LinkButton> builder, bool disabled = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.ToggleCss(Css.Disabled, disabled);
            return builder;
        }

        // IHasButtonExtensions

        public static ComponentBuilder<TConfig, TTag> SetSize<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, ButtonSize size)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasButtonExtensions
        {
            builder.Component.ToggleCss(size);
            return builder;
        }

        public static ComponentBuilder<TConfig, TTag> SetBlock<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, bool block = true)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasButtonExtensions
        {
            builder.Component.ToggleCss(Css.BtnBlock, block);
            return builder;
        }

        // IHasButtonStateExtensions

        public static ComponentBuilder<TConfig, TTag> SetState<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, ButtonState state)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasButtonStateExtensions
        {
            builder.Component.ToggleCss(state);
            return builder;
        }
    }
}
