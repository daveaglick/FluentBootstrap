using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentBootstrap.Forms
{
    public class FormInput : Tag
    {
        internal string Label { get; set; }
        internal bool LabelSrOnly { get; set; }

        internal FormInput(BootstrapHelper helper, string type) : base(helper, "input", "form-control")
        {
            MergeAttribute("type", type);
        }

        protected override void OnStart(TextWriter writer)
        {
            // Add the validation data
            string name = null;
            if (TagBuilder.Attributes.TryGetValue("name", out name) && !string.IsNullOrWhiteSpace(name))
            {
                // Set the id
                TagBuilder.GenerateId(name);

                // Set the validation class
                ModelState modelState;
                if (HtmlHelper.ViewData.ModelState.TryGetValue(name, out modelState) && modelState.Errors.Count > 0)
                {
                    CssClasses.Add(HtmlHelper.ValidationInputCssClassName);
                }

                // Add other validation attributes
                TagBuilder.MergeAttributes<string, object>(HtmlHelper.GetUnobtrusiveValidationAttributes(name, null));
            }

            // Append the form group
            TagBuilder formGroup = new TagBuilder("div");
            formGroup.AddCssClass("form-group");
            writer.Write(formGroup.ToString(TagRenderMode.StartTag));

            // Append the label
            if (!string.IsNullOrWhiteSpace(Label))
            {
                TagBuilder label = new TagBuilder("label");
                if (!string.IsNullOrWhiteSpace(name))
                    label.MergeAttribute("for", name);
                if (LabelSrOnly)
                    label.AddCssClass("sr-only");
                writer.Write(label.ToString(TagRenderMode.StartTag));
                writer.Write(Label);
                writer.Write(label.ToString(TagRenderMode.EndTag));
            }

            base.OnStart(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            base.OnFinish(writer);

            TagBuilder formGroup = new TagBuilder("div");
            writer.Write(formGroup.ToString(TagRenderMode.EndTag));
        }
    }
}
