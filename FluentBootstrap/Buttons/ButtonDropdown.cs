using FluentBootstrap.Dropdowns;
using FluentBootstrap.Html;
using FluentBootstrap.Icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Buttons
{
    public class ButtonDropdown : Tag, IHasIconExtensions, IHasButtonExtensions, IHasButtonStateExtensions, IHasTextContent,
        ICanCreate<DropdownDivider>,
        ICanCreate<DropdownHeader>,
        ICanCreate<DropdownLink>
    {
        private ButtonGroup _buttonGroup = null;
        public bool Split { get; set; }
        public bool Dropup { get; set; }

        internal ButtonDropdown(BootstrapHelper helper)
            : base(helper, "ul")
        {
        }

        protected override void OnStart(System.IO.TextWriter writer)
        {
            // Add the outer group
            _buttonGroup = GetHelper().ButtonGroup().Component;
            if(Dropup)
            {
                _buttonGroup.AddCss(Css.Dropup);
            }
            _buttonGroup.Start(writer);

            // Add the action button if split and copy over button CSS classes
            // But only create the split if we actually have some text to put in it
            if (Split && !string.IsNullOrWhiteSpace(TextContent))
            {
                Button button = GetHelper().Button(TextContent).Component;
                TextContent = null;
                foreach (string cssClass in CssClasses)
                {
                    button.CssClasses.Add(cssClass);
                }
                button.MergeAttributes(Attributes.Dictionary);
                Attributes.Dictionary.Clear();
                button.StartAndFinish(writer);
            }

            // Create the dropdown button, copy over CSS, add the text and caret, then render
            Button dropdown = GetHelper().Button(buttonType: ButtonType.Button).Component;
            dropdown.AddCss(Css.Btn, Css.BtnDefault, Css.DropdownToggle);
            dropdown.MergeAttribute("data-toggle", "dropdown");
            foreach (string cssClass in CssClasses)
            {
                dropdown.CssClasses.Add(cssClass);
            }
            dropdown.MergeAttributes(Attributes.Dictionary);
            Attributes.Dictionary.Clear();
            CssClasses.Clear();
            if (!string.IsNullOrWhiteSpace(TextContent))
            {
                dropdown.AddChild(GetHelper().Content(TextContent + " "));
            }
            else
            {
                Element element = GetHelper().Element("span").AddCss(Css.SrOnly).Component;
                element.AddChild(GetHelper().Content("Toggle Dropdown"));
                dropdown.AddChild(element);
            }
            dropdown.AddChild(GetHelper().Caret());
            TextContent = null;
            dropdown.StartAndFinish(writer);

            // Add CSS and attributes after we've copied all the user-specified stuff to the buttons
            MergeAttribute("role", "menu");
            AddCss(Css.DropdownMenu);   

            base.OnStart(writer);
        }

        protected override void OnFinish(System.IO.TextWriter writer)
        {
            base.OnFinish(writer);
            _buttonGroup.Finish(writer);
        }
    }
}
