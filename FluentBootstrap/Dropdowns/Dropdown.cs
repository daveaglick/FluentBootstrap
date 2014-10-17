using FluentBootstrap.Buttons;
//using FluentBootstrap.Forms;
using FluentBootstrap.Html;
using FluentBootstrap.Typography;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Dropdowns
{
    // TODO: REMOVE THIS!!
    internal interface IInputGroupButton : ITag { }

    public interface IDropdownCreator<TModel> : ITagCreator<TModel>
    {
    }

    public class DropdownWrapper<TModel> : TagWrapper<TModel>, IDropdownDividerCreator<TModel>, IDropdownHeaderCreator<TModel>, IDropdownLinkCreator<TModel>
    {
    }

    internal interface IDropdown : IButton
    {
    }

    public class Dropdown<TModel> : Tag<TModel, Dropdown<TModel>, DropdownWrapper<TModel>>, IDropdown, IHasButtonExtensions, IHasButtonStyleExtensions, IHasTextAttribute
    {
        private bool _dropdownButton = false;
        private bool _caret = true;
        private bool _menuRight;
        private bool _menuLeft;
        private Button<TModel> _button;
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
            // Create a button and copy over any button classes and text
            _button = Helper.Button();
            _button.RemoveCss(Css.BtnDefault);
            _button.AddCss(Css.DropdownToggle);
            _button.AddAttribute("data-toggle", "dropdown");
            foreach (string buttonClass in CssClasses.Where(x => x.StartsWith("btn")))
            {
                _button.CssClasses.Add(buttonClass);
            }
            CssClasses.RemoveWhere(x => x.StartsWith("btn"));
            if (!string.IsNullOrWhiteSpace(TextContent))
            {
                _button.AddChild(new Content<TModel>(Helper, TextContent + " "));
            }
            else
            {
                Element<TModel> element = new Element<TModel>(Helper, "span", Css.SrOnly);
                element.AddChild(new Content<TModel>(Helper, "Toggle Dropdown"));
                _button.AddChild(element);
            }
            TextContent = null;
            if(_caret)
            {
                _button.AddChild(Helper.Caret());
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
            _button.StartAndFinish(writer);

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
