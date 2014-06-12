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

        public static Button Button<TCreator>(this IComponentCreator<TCreator> creator, ButtonType buttonType = ButtonType.Button, ButtonStyle buttonStyle = ButtonStyle.Default, string text = null, object value = null)
            where TCreator : Button.ICreate
        {
            return new Button(creator.GetHelper(), buttonType, buttonStyle).Text(text).Value(value);
        }

        // LinkButton

        public static LinkButton LinkButton<TCreator>(this IComponentCreator<TCreator> creator, string text, string href = "#", ButtonStyle buttonStyle = ButtonStyle.Default)
            where TCreator : LinkButton.ICreate
        {
            return new LinkButton(creator.GetHelper(), buttonStyle).Text(text).Href(href);
        }

        public static LinkButton LinkButton<TCreator>(this IComponentCreator<TCreator> creator, string text, string actionName, string controllerName, object routeValues = null, ButtonStyle buttonStyle = ButtonStyle.Default)
            where TCreator : LinkButton.ICreate
        {
            return new LinkButton(creator.GetHelper(), buttonStyle).Text(text).Action(actionName, controllerName, routeValues);
        }

        public static LinkButton Disabled(this LinkButton linkButton, bool disabled = true)
        {
            linkButton.ToggleCssClass("disabled", disabled);
            return linkButton;
        }

        // IButton

        public static TButton BtnLg<TButton>(this TButton button, bool lg = true)
            where TButton : Tag, IButton
        {
            button.ToggleCssClass("btn-lg", lg, "btn-sm", "btn-xs");
            return button;
        }

        public static TButton BtnSm<TButton>(this TButton button, bool sm = true)
            where TButton : Tag, IButton
        {
            button.ToggleCssClass("btn-sm", sm, "btn-lg", "btn-xs");
            return button;
        }

        public static TButton BtnXs<TButton>(this TButton button, bool xs = true)
            where TButton : Tag, IButton
        {
            button.ToggleCssClass("btn-xs", xs, "btn-lg", "btn-sm");
            return button;
        }

        public static TButton BtnBlock<TButton>(this TButton button, bool block = true)
            where TButton : Tag, IButton
        {
            button.ToggleCssClass("btn-block", block);
            return button;
        }

        // TODO: Create and add an ILink interface to Button for adding links (including overloads for controller/action, etc.)
    }
}
