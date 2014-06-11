using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentBootstrap.Forms
{
    public abstract class FormControl : Tag, FluentBootstrap.Grids.IGridColumn
    {
        private FormGroup _formGroup = null;
        private Tag _columnWrapper = null;

        internal Label Label { get; set; }

        protected FormControl(BootstrapHelper helper, string tagName, params string[] cssClasses) 
            : base(helper, tagName, cssClasses)
        {
        }

        protected override void Prepare(TextWriter writer)
        {
            base.Prepare(writer);

            // Make sure we're in a form group
            FormGroup formGroup = GetComponent<FormGroup>();
            if (formGroup == null)
            {
                _formGroup = (FormGroup)new FormGroup(Helper).Start(writer, true);
                formGroup = _formGroup;
            }

            // Add the label
            Form form = GetComponent<Form>();
            if (Label != null)
            {
                // Set the label's for attribute to the input name
                string name = null;
                if (TagBuilder.Attributes.TryGetValue("name", out name) && !string.IsNullOrWhiteSpace(name))
                {
                    Label.For(name);
                }

                // Write the label
                writer.Write(Label.ToHtmlString());
            }

            // Add default column classes if we're horizontal and none have been explicitly set
            if (form != null && form.Horizontal && form.DefaultLabelWidth != null && !CssClasses.Any(x => x.StartsWith("col-")))
            {
                this.Md(BootstrapHelper.GridColumns - form.DefaultLabelWidth);
                if (Label == null && (formGroup == null || !formGroup.WroteLabel))
                {
                    // Also need to add an offset if no label
                    this.MdOffset(form.DefaultLabelWidth);
                }
            }

            // Move any grid column classes to a container class
            if (CssClasses.Any(x => x.StartsWith("col-")))
            {
                _columnWrapper = new Tag(Helper, "div", CssClasses.Where(x => x.StartsWith("col-")).ToArray());
                CssClasses.RemoveWhere(x => x.StartsWith("col-"));
                _columnWrapper.Start(writer, true);
            }
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

            base.OnStart(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            base.OnFinish(writer);

            // Pop wrapper elements if we added any
            Pop(_columnWrapper, writer);
            Pop(_formGroup, writer);
        }
    }
}
