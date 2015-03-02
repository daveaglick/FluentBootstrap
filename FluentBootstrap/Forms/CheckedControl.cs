using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class CheckedControl : FormControl, IHasValueAttribute, IHasNameAttribute
    {
        public bool Checked { get; set; }
        public bool Inline { get; set; }
        public string Description { get; set; }
        public bool SuppressLabelWrapper { get; set; }

        private Element _wrapper = null;
        private Element _label = null;

        internal CheckedControl(BootstrapHelper helper, string type)
            : base(helper, "input")
        {
            OutputEndTag = false;
            MergeAttribute("type", type);
        }
        
        protected override void OnStart(TextWriter writer)
        {            
            Prepare(writer);

            if(Checked)
            {
                MergeAttribute("checked", "checked");
            }

            // Add the description as child content
            if (!string.IsNullOrEmpty(Description))
            {
                AddChild(GetHelper().Content(" " + Description));
            }
            else if (Inline && !SuppressLabelWrapper)
            {
                // Add a space if we're inline without a description
                // This counters the problem of non-labeled checked controls when inline not positioning properly
                // From Bootstrap docs: "Currently only works on non-inline checkboxes and radios."
                AddChild(GetHelper().Content("&nbsp;"));
            }

            // See if we're in a horizontal form or form group
            Form form = GetComponent<Form>();
            FormGroup formGroup = GetComponent<FormGroup>();
            bool horizontal = form != null && form.Horizontal && (formGroup == null || !formGroup.Horizontal.HasValue || formGroup.Horizontal.Value);

            // Add the wrapper
            if (!Inline)
            {
                ComponentBuilder<BootstrapConfig, Element> builder = GetHelper().Element("div").AddCss(GetAttribute("type"));

                // Hack to make manual padding adjustments if we're horizontal
                if(horizontal)
                {
                    builder.AddStyle("padding-top", "0");
                }

                _wrapper = builder.Component;
                _wrapper.Start(writer);
            }

            // Add the label wrapper
            if (!SuppressLabelWrapper)
            {
                ComponentBuilder<BootstrapConfig, Element> labelBuilder = GetHelper().Element("label").AddCss(Inline ? GetAttribute("type") + "-inline" : GetAttribute("type"));

                // Another hack for manual padding adjustments if inline and horizontal
                if(Inline && horizontal)
                {
                    labelBuilder.AddStyle("padding-top", "0");
                }

                _label = labelBuilder.Component;
                _label.Start(writer);
            }

            base.OnStart(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            base.OnFinish(writer);

            // Finish the wrapper and label
            if (_label != null)
            {
                _label.Finish(writer);
            }
            if (_wrapper != null)
            {
                _wrapper.Finish(writer);
            }
        }
    }
}
