using FluentBootstrap.Buttons;
using FluentBootstrap.Forms;
using FluentBootstrap.Html;
using FluentBootstrap.Links;
using FluentBootstrap.Navs;
using FluentBootstrap.Typography;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Dropdowns
{
    public interface IDropdownCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class DropdownWrapper<TModel> : TagWrapper<TModel>, IDropdownDividerCreator<TModel>, IDropdownHeaderCreator<TModel>, IDropdownLinkCreator<TModel>
    {
    }

    internal interface IDropdown : IButton
    {
    }

    public class Dropdown<TModel> : Tag<TModel, Dropdown<TModel>, DropdownWrapper<TModel>>, IDropdown, IHasButtonExtensions, IHasButtonStateExtensions, IHasTextAttribute
    {
        private bool _dropdownButton = false;
        private bool _caret = true;
        private bool _menuRight;
        private bool _menuLeft;
        private Component _toggle;
        private Typography.List<TModel> _list;

        internal bool Caret
        {
            set { _caret = value; }
        }

        internal bool MenuRight
        {
            set { _menuRight = value; }
        }

        internal bool MenuLeft
        {
            set { _menuLeft = value; }
        }

        internal Dropdown(IComponentCreator<TModel> creator)
            : base(creator, "div", Css.Dropdown, Css.BtnDefault)
        {
        }

        protected override void PreStart(TextWriter writer)
        {
            // Check if we're in a nav
            if (GetComponent<INav>(true) != null)
            {
                TagName = "li";
                Link<TModel> link = Helper.Link(null);
                link.AddCss(Css.DropdownToggle);
                link.AddAttribute("data-toggle", "dropdown");
                _toggle = link;
            }
            else
            {
                // Create a button and copy over any button classes and text
                Button<TModel> button = Helper.Button();
                button.RemoveCss(Css.BtnDefault);
                button.AddCss(Css.DropdownToggle);
                button.AddAttribute("data-toggle", "dropdown");
                foreach (string buttonClass in CssClasses.Where(x => x.StartsWith("btn")))
                {
                    button.CssClasses.Add(buttonClass);
                }
                _toggle = button;
            }
            CssClasses.RemoveWhere(x => x.StartsWith("btn"));

            // Add the text and caret
            if (!string.IsNullOrWhiteSpace(TextContent))
            {
                _toggle.AddChild(new Content<TModel>(Helper, TextContent + " "));
            }
            else
            {
                Element<TModel> element = new Element<TModel>(Helper, "span", Css.SrOnly);
                element.AddChild(new Content<TModel>(Helper, "Toggle Dropdown"));
                _toggle.AddChild(element);
            }
            TextContent = null;
            if(_caret)
            {
                _toggle.AddChild(Helper.Caret());
            }

            // Check if we're in a IDropdownButton or IInputGroupButton, then
            // Check if we're in a button group, and if so change the outer CSS class
            // Do this after copying over the btn classes so this doesn't get copied
            if (GetComponent<IDropdownButton>(true) != null || GetComponent<IInputGroupButton>(true) != null)
            {
                _dropdownButton = true;
            }
            else if (GetComponent<IButtonGroup>(true) != null)
            {
                ToggleCss(Css.BtnGroup, true, Css.Dropdown);
            }

            // Create the list
            _list = Helper.List(ListType.Unordered);
            _list.AddCss(Css.DropdownMenu);
            _list.MergeAttribute("role", "menu");
            if(_menuRight)
            {
                _list.AddCss(Css.DropdownMenuRight);
            }
            if(_menuLeft)
            {
                _list.AddCss(Css.DropdownMenuLeft);
            }

            base.PreStart(writer);
        }

        protected override void OnStart(TextWriter writer)
        {
            if (!_dropdownButton)
            {
                base.OnStart(writer);
            }

            // Output the button
            _toggle.StartAndFinish(writer);

            // Output the start of the list
            _list.Start(writer, true);
        }

        protected override void OnFinish(TextWriter writer)
        {
            if (!_dropdownButton)
            {
                base.OnFinish(writer);
            }

            _list.Finish(writer);
        }
    }
}
