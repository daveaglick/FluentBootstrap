using FluentBootstrap.Buttons;
using FluentBootstrap.Forms;
using FluentBootstrap.Html;
using FluentBootstrap.Links;
using FluentBootstrap.Navbars;
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
    public class Dropdown : Tag, IHasButtonExtensions, IHasButtonStateExtensions, IHasTextContent,
        ICanCreate<DropdownDivider>,
        ICanCreate<DropdownHeader>,
        ICanCreate<DropdownLink>
    {
        private bool _inputGroupButton = false;
        private Component _toggle;
        private Typography.List _list;

        public bool Caret { get; set; }
        public bool MenuRight { get; set; }
        public bool MenuLeft { get; set; }

        internal Dropdown(BootstrapHelper helper)
            : base(helper, "div", Css.Dropdown, Css.BtnDefault)
        {
            Caret = true;
        }

        protected override void OnStart(TextWriter writer)
        {
            // Check if we're in a navbar, and if so, make sure we're in a navbar nav
            if (GetComponent<Navbar>() != null && GetComponent<NavbarNav>() == null)
            {
                GetHelper().NavbarNav().Component.Start(writer);
            }

            // Check if we're in a nav
            if (GetComponent<Nav>(true) != null || GetComponent<NavbarNav>(true) != null)
            {
                TagName = "li";
                Link link = GetHelper().Link(null).Component;
                link.AddCss(Css.DropdownToggle);
                link.MergeAttribute("data-toggle", "dropdown");
                _toggle = link;
            }
            else
            {
                // Create a button and copy over any button classes and text
                Button button = GetHelper().Button().Component;
                button.RemoveCss(Css.BtnDefault);
                button.AddCss(Css.DropdownToggle);
                button.MergeAttribute("data-toggle", "dropdown");
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
                _toggle.AddChild(GetHelper().Content(TextContent + " "));
            }
            else
            {
                Element element = GetHelper().Element("span").AddCss(Css.SrOnly).Component;
                element.AddChild(GetHelper().Content("Toggle Dropdown"));
                _toggle.AddChild(element);
            }
            TextContent = null;
            if (Caret)
            {
                _toggle.AddChild(GetHelper().Caret());
            }

            // Check if we're in a InputGroupButton, then
            // Check if we're in a button group, and if so change the outer CSS class
            // Do this after copying over the btn classes so this doesn't get copied
            if (GetComponent<InputGroupButton>(true) != null)
            {
                _inputGroupButton = true;
            }
            else if (GetComponent<ButtonGroup>(true) != null)
            {
                ToggleCss(Css.BtnGroup, true, Css.Dropdown);
            }

            // Create the list
            _list = GetHelper().List(ListType.Unordered).Component;
            _list.AddCss(Css.DropdownMenu);
            _list.MergeAttribute("role", "menu");
            if (MenuRight)
            {
                _list.AddCss(Css.DropdownMenuRight);
            }
            if (MenuLeft)
            {
                _list.AddCss(Css.DropdownMenuLeft);
            }

            // Start this component
            base.OnStart(_inputGroupButton ? new SuppressOutputWriter() : writer);

            // Output the button
            _toggle.StartAndFinish(writer);

            // Output the start of the list
            _list.Start(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            _list.Finish(writer);
            base.OnFinish(_inputGroupButton ? new SuppressOutputWriter() : writer);
        }
    }
}
