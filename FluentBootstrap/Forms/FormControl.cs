using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentBootstrap.Forms
{
    public abstract class FormControl<TModel> : Tag<TModel>, FluentBootstrap.Grids.IGridColumn, IFormValidation, IHasDisabledAttribute
    {
        private FormGroup<TModel> _formGroup = null;
        private Label<TModel> _label = null;
        internal string Help { get; set; }

        protected FormControl(BootstrapHelper<TModel> helper, string tagName, params string[] cssClasses) 
            : base(helper, tagName, cssClasses)
        {
        }

        internal Label<TModel> Label
        {
            set
            {
                _label = value;

                // Need to remove this from the pending components since it's similar to a child and will be output from this form control
                PendingComponents.Remove(HtmlHelper, value);
            }
        }

        protected override void Prepare(TextWriter writer)
        {
            base.Prepare(writer);

            // Make sure we're in a form group
            FormGroup<TModel> formGroup = GetComponent<FormGroup<TModel>>();
            if (formGroup == null)
            {
                _formGroup = new FormGroup<TModel>(Helper);
                formGroup = _formGroup;
            }

            // Move any validation classes to the form group, but only if it's implicit for this control and doesn't already have form validation classes
            if (CssClasses.Any(x => x.StartsWith("has-")) && _formGroup != null && !formGroup.CssClasses.Any(x => x.StartsWith("has-")))
            {
                foreach (string formValidation in CssClasses.Where(x => x.StartsWith("has-")))
                {
                    formGroup.CssClasses.Add(formValidation);
                }
            }
            CssClasses.RemoveWhere(x => x.StartsWith("has-"));

            // Start the new form group if we created one
            if (_formGroup != null)
            {
                _formGroup.Start(writer, true);
            }

            // Add the label
            if (_label != null)
            {
                // Set the label's for attribute to the input name
                string name = null;
                if (TagBuilder.Attributes.TryGetValue("name", out name) && !string.IsNullOrWhiteSpace(name))
                {
                    _label.For(name);
                }

                // Write the label
                _label.StartAndFinish(writer);
            }

            // Add default column classes if we're horizontal and none have been explicitly set
            Form<TModel> form = GetComponent<Form<TModel>>();
            if (form != null && form.Horizontal && form.DefaultLabelWidth != null && !CssClasses.Any(x => x.StartsWith("col-")))
            {
                this.Md(BootstrapHelper<TModel>.GridColumns - form.DefaultLabelWidth);
                if (_label == null && (formGroup == null || !formGroup.WroteLabel))
                {
                    // Also need to add an offset if no label
                    this.MdOffset(form.DefaultLabelWidth);
                }
            }

            // Move any grid column classes to a container class
            if (CssClasses.Any(x => x.StartsWith("col-")) && formGroup.ColumnWrapper == null)
            {
                formGroup.ColumnWrapper = new Tag<TModel>(Helper, "div", CssClasses.Where(x => x.StartsWith("col-")).ToArray());
                formGroup.ColumnWrapper.Start(writer, true);
            }
            CssClasses.RemoveWhere(x => x.StartsWith("col-"));
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
                    CssClasses.Add(System.Web.Mvc.HtmlHelper.ValidationInputCssClassName);
                }

                // Add other validation attributes
                TagBuilder.MergeAttributes<string, object>(HtmlHelper.GetUnobtrusiveValidationAttributes(name, null));
            }

            base.OnStart(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            // Add the help text
            if (!string.IsNullOrEmpty(Help))
            {
                new Tag<TModel>(Helper, "p", "help-block")
                    .AddChild(new Content<TModel>(Helper, Help))
                    .StartAndFinish(writer);
            }

            base.OnFinish(writer);

            Pop(_formGroup, writer);
        }

        public interface ICreate : ICreateComponent<TModel>
        {
        }
    }
}
