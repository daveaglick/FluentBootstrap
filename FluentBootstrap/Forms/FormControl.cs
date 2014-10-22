using FluentBootstrap.Grids;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentBootstrap.Forms
{
    public interface IFormControlCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class FormControlWrapper<TModel> : TagWrapper<TModel>,
        IHelpBlockCreator<TModel>
    {
    }

    internal interface IFormControl : ITag
    {
    }

    public abstract class FormControl<TModel, TThis, TWrapper> : Tag<TModel, TThis, TWrapper>, IFormControl, IHasGridColumnExtensions, IFormValidation, IHasDisabledAttribute
        where TThis : FormControl<TModel, TThis, TWrapper>
        where TWrapper : FormControlWrapper<TModel>, new()
    {
        private FormGroup<TModel> _formGroup = null;
        private ILabel _label = null;
        internal string Help { get; set; }
        internal bool EnsureFormGroup { get; set; }
        private bool _prepared = false;

        protected FormControl(IComponentCreator<TModel> creator, string tagName, params string[] cssClasses) 
            : base(creator, tagName, cssClasses)
        {
            EnsureFormGroup = true;
        }

        internal ILabel Label
        {
            set { _label = value; }
        }

        // This prepares the outer form group if we need one
        // Needs to be in a separate method so that derived classes can create the form group before outputting any wrappers of their own
        protected void Prepare(TextWriter writer)
        {
            // Only prepare once
            if(_prepared)
            {
                return;
            }
            _prepared = true;

            // Make sure we're in a form group
            IFormGroup formGroup = GetComponent<IFormGroup>();
            if (formGroup == null && EnsureFormGroup)
            {
                _formGroup = new FormGroup<TModel>(Helper);
                formGroup = _formGroup;
            }

            // Move any validation classes to the form group, but only if it's implicit for this control and doesn't already have any
            if (CssClasses.Any(x => x.StartsWith("has-")) && _formGroup != null && formGroup != null && !formGroup.CssClasses.Any(x => x.StartsWith("has-")))
            {
                foreach (string formValidation in CssClasses.Where(x => x.StartsWith("has-")))
                {
                    formGroup.CssClasses.Add(formValidation);
                }
                CssClasses.RemoveWhere(x => x.StartsWith("has-"));
            }

            // Move any grid column classes to the form group, but only if it's implicit for this control and doesn't already have any
            if (CssClasses.Any(x => x.StartsWith("col-")) && _formGroup != null && formGroup != null && !formGroup.CssClasses.Any(x => x.StartsWith("col-")))
            {
                foreach (string col in CssClasses.Where(x => x.StartsWith("col-")))
                {
                    formGroup.CssClasses.Add(col);
                }
                CssClasses.RemoveWhere(x => x.StartsWith("col-"));
            }

            // Add the label to the form group or write it
            if (_label != null)
            {
                // Set the label's for attribute to the input name
                string name = null;
                if (TagBuilder.Attributes.TryGetValue("name", out name) && !string.IsNullOrWhiteSpace(name))
                {
                    _label.MergeAttribute("for", name);
                }

                // Add or write the label
                if (_formGroup != null)
                {
                    _formGroup.Label = _label;
                }
                else
                {
                    _label.StartAndFinish(writer);
                }
            }

            // Start the new form group if we created one
            if (_formGroup != null)
            {
                _formGroup.Start(writer);
            }

            _prepared = true;
        }

        protected override void OnStart(TextWriter writer)
        {
            Prepare(writer);

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
            base.OnFinish(writer);

            // Add the help text
            if (!string.IsNullOrEmpty(Help))
            {
                new HelpBlock<TModel>(Helper).SetText(Help).StartAndFinish(writer);
            }

            Pop(_formGroup, writer);
        }
    }

    public class FormControl<TModel> : FormControl<TModel, FormControl<TModel>, FormControlWrapper<TModel>>, IFormControl
    {
        internal FormControl(IComponentCreator<TModel> creator)
            : base(creator, "div")
        {
        }
    }
}
