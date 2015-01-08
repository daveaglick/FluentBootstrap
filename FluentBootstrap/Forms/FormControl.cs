using FluentBootstrap.Grids;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class FormControl : Tag, IHasGridColumnExtensions, IFormValidation, IHasDisabledAttribute,
        ICanCreate<HelpBlock>
    {
        private FormGroup _formGroup = null;
        private ControlLabel _label = null;
        internal string Help { get; set; }
        internal bool EnsureFormGroup { get; set; }
        private bool _prepared = false;

        protected FormControl(IComponentCreator creator, string tagName, params string[] cssClasses) 
            : base(creator, tagName, cssClasses)
        {
            EnsureFormGroup = true;
        }

        internal ControlLabel Label
        {
            set { _label = value; }
        }

        // This prepares the outer form group if we need one
        // Needs to be in a separate method so that derived classes can create the form group before outputting any wrappers of their own
        protected void Prepare<THelper>(THelper helper, TextWriter writer)
            where THelper : BootstrapHelper<THelper>
        {
            // Only prepare once
            if(_prepared)
            {
                return;
            }
            _prepared = true;

            // Make sure we're in a form group
            FormGroup formGroup = GetComponent<FormGroup>(helper);
            if (formGroup == null && EnsureFormGroup)
            {
                _formGroup = new FormGroup(helper);
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
                string name = Attributes.GetValue("name");
                if (!string.IsNullOrWhiteSpace(name))
                {
                    _label.MergeAttribute("for", name);
                }

                // Add or write the label
                if (_formGroup != null)
                {
                    _formGroup.ControlLabel = _label;
                }
                else
                {
                    _label.StartAndFinish(helper, writer);
                }
            }

            // Start the new form group if we created one
            if (_formGroup != null)
            {
                _formGroup.Start(helper, writer);
            }

            _prepared = true;
        }

        protected override void OnStart<THelper>(THelper helper, TextWriter writer)
        {
            Prepare(helper, writer);

            base.OnStart(helper, writer);
        }

        protected override void OnFinish<THelper>(THelper helper, TextWriter writer)
        {
            base.OnFinish(helper, writer);

            // Add the help text
            if (!string.IsNullOrEmpty(Help))
            {
                GetBuilder(helper, new HelpBlock(helper)).SetText(Help).Component.StartAndFinish(helper, writer);
            }

            Pop(helper, _formGroup, writer);
        }
    }
}
