using FluentBootstrap.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentBootstrap.Internals;

namespace FluentBootstrap
{
    public static class ButtonExtensions
    {
        // Button

        public static Button<THelper> Button<THelper>(this IButtonCreator<THelper> creator, string text = null, ButtonType buttonType = ButtonType.Button, object value = null)
            where THelper : BootstrapHelper<THelper>
        {
            return new Button<THelper>(creator, buttonType).SetText(text).SetValue(value);
        }
        
        // Button groups

        public static ButtonGroup<THelper> ButtonGroup<THelper>(this IButtonGroupCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new ButtonGroup<THelper>(creator);
        }

        public static ButtonGroup<THelper> SetSize<THelper>(this ButtonGroup<THelper> buttonGroup, ButtonGroupSize size)
            where THelper : BootstrapHelper<THelper>
        {
            buttonGroup.ToggleCss(size);
            return buttonGroup;
        }

        public static ButtonGroup<THelper> SetVertical<THelper>(this ButtonGroup<THelper> buttonGroup, bool vertical = true)
            where THelper : BootstrapHelper<THelper>
        {
            if (vertical)
            {
                buttonGroup.ToggleCss(Css.BtnGroupVertical, true, Css.BtnGroup);
            }
            else
            {
                buttonGroup.ToggleCss(Css.BtnGroup, true, Css.BtnGroupVertical);
            }
            return buttonGroup;
        }

        public static ButtonGroup<THelper> SetJustified<THelper>(this ButtonGroup<THelper> buttonGroup, bool justified = true)
            where THelper : BootstrapHelper<THelper>
        {
            buttonGroup.ToggleCss(Css.BtnGroupJustified, justified);
            return buttonGroup;
        }

        public static ButtonToolbar<THelper> ButtonToolbar<THelper>(this IButtonToolbarCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new ButtonToolbar<THelper>(creator);
        }

        // Dropdown buttons

        public static DropdownButton<THelper> DropdownButton<THelper>(this IDropdownButtonCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new DropdownButton<THelper>(creator);
        }

        public static DropdownButton<THelper> SetDropup<THelper>(this DropdownButton<THelper> dropdownButton, bool dropup = true)
            where THelper : BootstrapHelper<THelper>
        {
            dropdownButton.ToggleCss(Css.Dropup, dropup);
            return dropdownButton;
        }

        // LinkButton

        public static LinkButton<THelper> LinkButton<THelper>(this ILinkButtonCreator<THelper> creator, string text, string href = "#")
            where THelper : BootstrapHelper<THelper>
        {
            return new LinkButton<THelper>(creator).SetText(text).SetHref(href);
        }

        public static LinkButton<THelper> SetDisabled<THelper>(this LinkButton<THelper> linkButton, bool disabled = true)
            where THelper : BootstrapHelper<THelper>
        {
            linkButton.ToggleCss(Css.Disabled, disabled);
            return linkButton;
        }

        // IHasButtonExtensions

        public static TThis SetSize<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, ButtonSize size)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasButtonExtensions
            where TWrapper : TagWrapper<THelper>, new()
        {
            return component.GetThis().ToggleCss(size);
        }

        public static TThis SetBlock<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, bool block = true)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasButtonExtensions
            where TWrapper : TagWrapper<THelper>, new()
        {
            return component.GetThis().ToggleCss(Css.BtnBlock, block);
        }

        // IHasButtonStateExtensions

        public static TThis SetState<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, ButtonState state)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasButtonStateExtensions
            where TWrapper : TagWrapper<THelper>, new()
        {
            return component.GetThis().ToggleCss(state);
        }
    }
}
