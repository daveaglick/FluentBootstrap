using FluentBootstrap.Buttons;
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
    internal interface IDropdown : IButton
    {
    }

    public interface IDropdownCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public interface IDropdownItemCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class Dropdown<TModel> : Tag<TModel, Dropdown<TModel>>, IDropdown, IHasButtonExtensions, IHasTextAttribute,
        IDropdownItemCreator<TModel>
    {
        private readonly ButtonStyle _buttonStyle;
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

        internal Dropdown(BootstrapHelper<TModel> helper, ButtonStyle buttonStyle)
            : base(helper, "div", Css.Dropdown)
        {
            _buttonStyle = buttonStyle;
        }

        protected override void PreStart(TextWriter writer)
        {
            // Create a button and copy over any button classes and text
            _button = Helper.Button(null, _buttonStyle);
            _button.AddCss(Css.DropdownToggle);
            _button.AddAttribute("data-toggle", "dropdown");
            foreach (string buttonClass in CssClasses.Where(x => x.StartsWith("btn")))
            {
                _button.CssClasses.Add(buttonClass);
            }
            CssClasses.RemoveWhere(x => x.StartsWith("btn"));
            _button.AddChild(new Content<TModel>(Helper, TextContent + " "));
            TextContent = null;
            if(_caret)
            {
                _button.AddChild(Helper.Caret());
            }

            // Check if we're in a button group, and if so change the outer CSS class
            // Do this after copying over the btn classes so this doesn't get copied
            if (GetComponent<IButtonGroup>(true) != null)
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
            base.OnStart(writer);

            // Output the button
            _button.StartAndFinish(writer);

            // Output the start of the list
            _list.Start(writer, true);
        }

        protected override void OnFinish(TextWriter writer)
        {
            base.OnFinish(writer);

            _list.Finish(writer);
        }
    }
}
