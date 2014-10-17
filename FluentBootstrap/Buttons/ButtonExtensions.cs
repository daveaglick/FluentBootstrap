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

        public static Button<TModel> Button<TModel>(this IButtonCreator<TModel> creator, string text = null, ButtonType buttonType = ButtonType.Button, object value = null)
        {
            return new Button<TModel>(creator, buttonType).SetText(text).SetValue(value);
        }
        
        // Button groups

        public static ButtonGroup<TModel> ButtonGroup<TModel>(this IButtonGroupCreator<TModel> creator)
        {
            return new ButtonGroup<TModel>(creator);
        }

        public static ButtonGroup<TModel> SetSize<TModel>(this ButtonGroup<TModel> buttonGroup, ButtonGroupSize size)
        {
            buttonGroup.ToggleCss(size);
            return buttonGroup;
        }

        public static ButtonGroup<TModel> SetVertical<TModel>(this ButtonGroup<TModel> buttonGroup, bool vertical = true)
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

        public static ButtonGroup<TModel> SetJustified<TModel>(this ButtonGroup<TModel> buttonGroup, bool justified = true)
        {
            buttonGroup.ToggleCss(Css.BtnGroupJustified, justified);
            return buttonGroup;
        }

        public static ButtonToolbar<TModel> ButtonToolbar<TModel>(this IButtonToolbarCreator<TModel> creator)
        {
            return new ButtonToolbar<TModel>(creator);
        }

        // Dropdown buttons

        public static DropdownButton<TModel> DropdownButton<TModel>(this IDropdownButtonCreator<TModel> creator)
        {
            return new DropdownButton<TModel>(creator);
        }

        public static DropdownButton<TModel> SetDropup<TModel>(this DropdownButton<TModel> dropdownButton, bool dropup = true)
        {
            dropdownButton.ToggleCss(Css.Dropup, dropup);
            return dropdownButton;
        }

        // LinkButton

        public static LinkButton<TModel> LinkButton<TModel>(this ILinkButtonCreator<TModel> creator, string text, string href = "#")
        {
            return new LinkButton<TModel>(creator).SetText(text).SetHref(href);
        }

        public static LinkButton<TModel> LinkButton<TModel>(this ILinkButtonCreator<TModel> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return new LinkButton<TModel>(creator).SetText(text).SetAction(actionName, controllerName, routeValues);
        }

        public static LinkButton<TModel> SetDisabled<TModel>(this LinkButton<TModel> linkButton, bool disabled = true)
        {
            linkButton.ToggleCss(Css.Disabled, disabled);
            return linkButton;
        }

        // IHasButtonExtensions

        public static TThis SetSize<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, ButtonSize size)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasButtonExtensions
            where TWrapper : TagWrapper<TModel>, new()
        {
            return component.GetThis().ToggleCss(size);
        }

        public static TThis SetBlock<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, bool block = true)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasButtonExtensions
            where TWrapper : TagWrapper<TModel>, new()
        {
            return component.GetThis().ToggleCss(Css.BtnBlock, block);
        }

        // IHasButtonStyleExtensions

        public static TThis SetStyle<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, ButtonStyle style)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasButtonStyleExtensions
            where TWrapper : TagWrapper<TModel>, new()
        {
            return component.GetThis().ToggleCss(style);
        }
    }
}
