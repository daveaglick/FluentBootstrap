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

        public static Button<TModel> Button<TModel>(this Button<TModel>.ICreate creator, ButtonType buttonType = ButtonType.Button, ButtonStyle buttonStyle = ButtonStyle.Default, string text = null, object value = null)
        {
            return new Button<TModel>(creator.GetHelper(), buttonType, buttonStyle).Text(text).Value(value);
        }

        // LinkButton

        public static LinkButton<TModel> LinkButton<TModel>(this LinkButton<TModel>.ICreate creator, string text, string href = "#", ButtonStyle buttonStyle = ButtonStyle.Default)
        {
            return new LinkButton<TModel>(creator.GetHelper(), buttonStyle).Text(text).Href(href);
        }

        public static LinkButton<TModel> LinkButton<TModel>(this LinkButton<TModel>.ICreate creator, string text, string actionName, string controllerName, object routeValues = null, ButtonStyle buttonStyle = ButtonStyle.Default)
        {
            return new LinkButton<TModel>(creator.GetHelper(), buttonStyle).Text(text).Action(actionName, controllerName, routeValues);
        }

        public static LinkButton<TModel> Disabled<TModel>(this LinkButton<TModel> linkButton, bool disabled = true)
        {
            linkButton.ToggleCssClass("disabled", disabled);
            return linkButton;
        }

        // IButton

        public static TButton BtnLg<TButton, TModel>(this TButton button, bool lg = true)
            where TButton : Tag<TModel>, IButton
        {
            button.ToggleCssClass("btn-lg", lg, "btn-sm", "btn-xs");
            return button;
        }

        public static TButton BtnSm<TButton, TModel>(this TButton button, bool sm = true)
            where TButton : Tag<TModel>, IButton
        {
            button.ToggleCssClass("btn-sm", sm, "btn-lg", "btn-xs");
            return button;
        }

        public static TButton BtnXs<TButton, TModel>(this TButton button, bool xs = true)
            where TButton : Tag<TModel>, IButton
        {
            button.ToggleCssClass("btn-xs", xs, "btn-lg", "btn-sm");
            return button;
        }

        public static TButton BtnBlock<TButton, TModel>(this TButton button, bool block = true)
            where TButton : Tag<TModel>, IButton
        {
            button.ToggleCssClass("btn-block", block);
            return button;
        }
    }
}
