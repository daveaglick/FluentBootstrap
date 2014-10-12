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
            return new Button<TModel>(creator.GetHelper(), buttonType).Text(text).Value(value);
        }
        
        // Button groups

        public static ButtonGroup<TModel> ButtonGroup<TModel>(this IButtonGroupCreator<TModel> creator)
        {
            return new ButtonGroup<TModel>(creator.GetHelper());
        }

        public static ButtonGroup<TModel> BtnGroupLg<TModel>(this ButtonGroup<TModel> buttonGroup, bool lg = true)
        {
            buttonGroup.ToggleCss(Css.BtnGroupLg, lg, Css.BtnGroupSm, Css.BtnGroupXs);
            return buttonGroup;
        }

        public static ButtonGroup<TModel> BtnGroupSm<TModel>(this ButtonGroup<TModel> buttonGroup, bool sm = true)
        {
            buttonGroup.ToggleCss(Css.BtnGroupSm, sm, Css.BtnGroupLg, Css.BtnGroupXs);
            return buttonGroup;
        }

        public static ButtonGroup<TModel> BtnGroupXs<TModel>(this ButtonGroup<TModel> buttonGroup, bool xs = true)
        {
            buttonGroup.ToggleCss(Css.BtnGroupXs, xs, Css.BtnGroupSm, Css.BtnGroupLg);
            return buttonGroup;
        }

        public static ButtonGroup<TModel> Vertical<TModel>(this ButtonGroup<TModel> buttonGroup, bool vertical = true)
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

        public static ButtonGroup<TModel> Justified<TModel>(this ButtonGroup<TModel> buttonGroup, bool justified = true)
        {
            buttonGroup.ToggleCss(Css.BtnGroupJustified, justified);
            return buttonGroup;
        }

        public static ButtonToolbar<TModel> ButtonToolbar<TModel>(this IButtonToolbarCreator<TModel> creator)
        {
            return new ButtonToolbar<TModel>(creator.GetHelper());
        }

        // Dropdown buttons

        public static DropdownButton<TModel> DropdownButton<TModel>(this IDropdownButtonCreator<TModel> creator)
        {
            return new DropdownButton<TModel>(creator.GetHelper());
        }

        public static DropdownButton<TModel> Dropup<TModel>(this DropdownButton<TModel> dropdownButton, bool dropup = true)
        {
            dropdownButton.ToggleCss(Css.Dropup, dropup);
            return dropdownButton;
        }

        // LinkButton

        public static LinkButton<TModel> LinkButton<TModel>(this ILinkButtonCreator<TModel> creator, string text, string href = "#")
        {
            return new LinkButton<TModel>(creator.GetHelper()).Text(text).Href(href);
        }

        public static LinkButton<TModel> LinkButton<TModel>(this ILinkButtonCreator<TModel> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return new LinkButton<TModel>(creator.GetHelper()).Text(text).Action(actionName, controllerName, routeValues);
        }

        public static LinkButton<TModel> Disabled<TModel>(this LinkButton<TModel> linkButton, bool disabled = true)
        {
            linkButton.ToggleCss(Css.Disabled, disabled);
            return linkButton;
        }

        // IHasButtonExtensions

        public static TThis BtnLg<TModel, TThis>(this Component<TModel, TThis> component, bool lg = true)
            where TThis : Tag<TModel, TThis>, IHasButtonExtensions
        {
            TThis tag = component.GetThis();
            tag.ToggleCss(Css.BtnLg, lg, Css.BtnSm, Css.BtnXs);
            return tag;
        }

        public static TThis BtnSm<TModel, TThis>(this Component<TModel, TThis> component, bool sm = true)
            where TThis : Tag<TModel, TThis>, IHasButtonExtensions
        {
            TThis tag = component.GetThis();
            tag.ToggleCss(Css.BtnSm, sm, Css.BtnLg, Css.BtnXs);
            return tag;
        }

        public static TThis BtnXs<TModel, TThis>(this Component<TModel, TThis> component, bool xs = true)
            where TThis : Tag<TModel, TThis>, IHasButtonExtensions
        {
            TThis tag = component.GetThis();
            tag.ToggleCss(Css.BtnXs, xs, Css.BtnLg, Css.BtnSm);
            return tag;
        }

        public static TThis BtnBlock<TModel, TThis>(this Component<TModel, TThis> component, bool block = true)
            where TThis : Tag<TModel, TThis>, IHasButtonExtensions
        {
            TThis tag = component.GetThis();
            tag.ToggleCss(Css.BtnBlock, block);
            return tag;
        }

        // IHasButtonStyleExtensions

        public static TThis BtnDefault<TModel, TThis>(this Component<TModel, TThis> component, bool def = true)
            where TThis : Tag<TModel, TThis>, IHasButtonStyleExtensions
        {
            TThis tag = component.GetThis();
            tag.ToggleCss(Css.BtnDefault, def, Css.BtnPrimary, Css.BtnSuccess, Css.BtnInfo, Css.BtnWarning, Css.BtnDanger, Css.BtnLink);
            return tag;
        }

        public static TThis BtnPrimary<TModel, TThis>(this Component<TModel, TThis> component, bool primary = true)
            where TThis : Tag<TModel, TThis>, IHasButtonStyleExtensions
        {
            TThis tag = component.GetThis();
            tag.ToggleCss(Css.BtnPrimary, primary, Css.BtnDefault, Css.BtnSuccess, Css.BtnInfo, Css.BtnWarning, Css.BtnDanger, Css.BtnLink);
            return tag;
        }

        public static TThis BtnSuccess<TModel, TThis>(this Component<TModel, TThis> component, bool success = true)
            where TThis : Tag<TModel, TThis>, IHasButtonStyleExtensions
        {
            TThis tag = component.GetThis();
            tag.ToggleCss(Css.BtnSuccess, success, Css.BtnPrimary, Css.BtnDefault, Css.BtnInfo, Css.BtnWarning, Css.BtnDanger, Css.BtnLink);
            return tag;
        }

        public static TThis BtnInfo<TModel, TThis>(this Component<TModel, TThis> component, bool info = true)
            where TThis : Tag<TModel, TThis>, IHasButtonStyleExtensions
        {
            TThis tag = component.GetThis();
            tag.ToggleCss(Css.BtnInfo, info, Css.BtnPrimary, Css.BtnSuccess, Css.BtnDefault, Css.BtnWarning, Css.BtnDanger, Css.BtnLink);
            return tag;
        }

        public static TThis BtnWarning<TModel, TThis>(this Component<TModel, TThis> component, bool warning = true)
            where TThis : Tag<TModel, TThis>, IHasButtonStyleExtensions
        {
            TThis tag = component.GetThis();
            tag.ToggleCss(Css.BtnWarning, warning, Css.BtnPrimary, Css.BtnSuccess, Css.BtnInfo, Css.BtnDefault, Css.BtnDanger, Css.BtnLink);
            return tag;
        }

        public static TThis BtnDanger<TModel, TThis>(this Component<TModel, TThis> component, bool danger = true)
            where TThis : Tag<TModel, TThis>, IHasButtonStyleExtensions
        {
            TThis tag = component.GetThis();
            tag.ToggleCss(Css.BtnDanger, danger, Css.BtnPrimary, Css.BtnSuccess, Css.BtnInfo, Css.BtnWarning, Css.BtnDefault, Css.BtnLink);
            return tag;
        }

        public static TThis BtnLink<TModel, TThis>(this Component<TModel, TThis> component, bool link = true)
            where TThis : Tag<TModel, TThis>, IHasButtonStyleExtensions
        {
            TThis tag = component.GetThis();
            tag.ToggleCss(Css.BtnLink, link, Css.BtnPrimary, Css.BtnSuccess, Css.BtnInfo, Css.BtnWarning, Css.BtnDanger, Css.BtnDefault);
            return tag;
        }
    }
}
