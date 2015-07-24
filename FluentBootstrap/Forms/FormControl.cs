using FluentBootstrap.Grids;
using System.IO;
using System.Linq;

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
            protected get { return _label; }
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
                // Set the label's for attribute to the input id
                string id = Attributes.GetValue("id");
                if (!string.IsNullOrWhiteSpace(id))
                {
                    _label.MergeAttribute("for", id);
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

        public virtual bool HasLabel
        {
            get { return _label != null; }
        }

        public virtual void AddLabelCss(params string[] cssClasses)
        {
            if (_label != null)
            {
                _label.AddCss(cssClasses);                
            }
        }

        public virtual void RemoveLabelCss(params string[] cssClasses)
        {
            if (_label != null)
            {
                _label.RemoveCss(cssClasses);
            }
        }
    }
}
