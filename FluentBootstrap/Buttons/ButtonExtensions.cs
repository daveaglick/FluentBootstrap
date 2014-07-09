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

        public static Button<TModel> Button<TModel>(this IButtonCreator<TModel> creator, ButtonType buttonType = ButtonType.Button, ButtonStyle buttonStyle = ButtonStyle.Default, string text = null, object value = null)
        {
            return new Button<TModel>(creator.GetHelper(), buttonType, buttonStyle).Text(text).Value(value);
        }

        // LinkButton

        public static LinkButton<TModel> LinkButton<TModel>(this ILinkButtonCreator<TModel> creator, string text, string href = "#", ButtonStyle buttonStyle = ButtonStyle.Default)
        {
            return new LinkButton<TModel>(creator.GetHelper(), buttonStyle).Text(text).Href(href);
        }

        public static LinkButton<TModel> LinkButton<TModel>(this ILinkButtonCreator<TModel> creator, string text, string actionName, string controllerName, object routeValues = null, ButtonStyle buttonStyle = ButtonStyle.Default)
        {
            return new LinkButton<TModel>(creator.GetHelper(), buttonStyle).Text(text).Action(actionName, controllerName, routeValues);
        }

        public static LinkButton<TModel> Disabled<TModel>(this LinkButton<TModel> linkButton, bool disabled = true)
        {
            linkButton.ToggleCssClass(Css.Disabled, disabled);
            return linkButton;
        }

        // IHasButtonExtensions

        public static TThis BtnLg<TModel, TThis>(this Component<TModel, TThis> component, bool lg = true)
            where TThis : Tag<TModel, TThis>, IHasButtonExtensions
        {
            TThis tag = component.GetThis();
            tag.ToggleCssClass(Css.BtnLg, lg, Css.BtnSm, Css.BtnXs);
            return tag;
        }

        public static TThis BtnSm<TModel, TThis>(this Component<TModel, TThis> component, bool sm = true)
            where TThis : Tag<TModel, TThis>, IHasButtonExtensions
        {
            TThis tag = component.GetThis();
            tag.ToggleCssClass(Css.BtnSm, sm, Css.BtnLg, Css.BtnXs);
            return tag;
        }

        public static TThis BtnXs<TModel, TThis>(this Component<TModel, TThis> component, bool xs = true)
            where TThis : Tag<TModel, TThis>, IHasButtonExtensions
        {
            TThis tag = component.GetThis();
            tag.ToggleCssClass(Css.BtnXs, xs, Css.BtnLg, Css.BtnSm);
            return tag;
        }

        public static TThis BtnBlock<TModel, TThis>(this Component<TModel, TThis> component, bool block = true)
            where TThis : Tag<TModel, TThis>, IHasButtonExtensions
        {
            TThis tag = component.GetThis();
            tag.ToggleCssClass(Css.BtnBlock, block);
            return tag;
        }
    }
}
