using FluentBootstrap.Grids;
using FluentBootstrap.Html;
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
        private Tag _wrapper = null;
        private ControlLabel _label = null;
        private bool _prepared = false;

        public string Help { get; set; }
        public bool EnsureFormGroup { get; set; }

        protected FormControl(BootstrapHelper helper, string tagName, params string[] cssClasses) 
            : base(helper, tagName, cssClasses)
        {
            EnsureFormGroup = true;
        }

        internal FormControl(BootstrapHelper helper)
            : this(helper, "div")
        {
        }

        public ControlLabel Label
        {
            set { _label = value; }
        }

        // This prepares the outer form group if we need one
        // Needs to be in a separate method so that derived classes can create the form group before outputting any wrappers of their own
        public void Prepare(TextWriter writer)
        {
            // Only prepare once
            if(_prepared)
            {
                return;
            }
            _prepared = true;

            // Make sure we're in a form group, but only if we're also in a form
            FormGroup formGroup = null;
            if (GetComponent<Form>() != null && GetComponent<FormGroup>() == null && EnsureFormGroup)
            {
                formGroup = new FormGroup(GetHelper());
                _wrapper = formGroup;
            }

            // Move any validation classes to the wrapper
            if (CssClasses.Any(x => x.StartsWith("has-")))
            {
                if(_wrapper == null)
                {
                    _wrapper = GetHelper().Element("div").Component;
                }
                foreach (string formValidation in CssClasses.Where(x => x.StartsWith("has-")))
                {
                    _wrapper.CssClasses.Add(formValidation);
                }
                CssClasses.RemoveWhere(x => x.StartsWith("has-"));
            }

            // Move any grid column classes to the wrapper
            if (CssClasses.Any(x => x.StartsWith("col-")))
            {
                if (_wrapper == null)
                {
                    _wrapper = GetHelper().Element("div").Component;
                }
                foreach (string col in CssClasses.Where(x => x.StartsWith("col-")))
                {
                    _wrapper.CssClasses.Add(col);
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
                if (formGroup != null)
                {
                    formGroup.ControlLabel = _label;
                }
                else
                {
                    _label.StartAndFinish(writer);
                }
            }

            // Start the new form group if we created one
            if (_wrapper != null)
            {
                _wrapper.Start(writer);
            }

            _prepared = true;
        }

        protected override void OnStart(TextWriter writer)
        {
            Prepare(writer);

            base.OnStart(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            base.OnFinish(writer);

            // Add the help text
            if (!string.IsNullOrEmpty(Help))
            {
                GetBuilder(new HelpBlock(GetHelper())).SetText(Help).Component.StartAndFinish(writer);
            }

            Pop(_wrapper, writer);
        }
    }
}
