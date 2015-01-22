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
        public bool Inline { get; set; }
        public string Description { get; set; }
        public bool SuppressLabelWrapper { get; set; }

        private Element _wrapper = null;
        private Element _label = null;

        internal CheckedControl(BootstrapHelper helper, string type)
            : base(helper, "input")
        {
            MergeAttribute("type", type);
        }

        protected override bool OutputEndTag
        {
            get { return false; }
        }
        
        protected override void OnStart(TextWriter writer)
        {
            Prepare(writer);

            // Add the description as child content
            if (!string.IsNullOrEmpty(Description))
            {
                AddChild(GetHelper().Content(" " + Description));
            }

            // Add the wrapper
            if (!Inline)
            {
                ComponentBuilder<BootstrapConfig, Element> builder = GetHelper().Element("div").AddCss(GetAttribute("type"));

                // Hack to make manual padding adjustments if we're in a horizontal form or form group
                Form form = GetComponent<Form>();
                FormGroup formGroup = GetComponent<FormGroup>();
                if(form != null && form.Horizontal && (formGroup == null || !formGroup.Horizontal.HasValue || formGroup.Horizontal.Value))
                {
                    builder.AddStyle("padding-top", "0");
                }

                _wrapper = builder.Component;
                _wrapper.Start(writer);
            }

            // Add the label wrapper
            if (!SuppressLabelWrapper)
            {
                _label = GetHelper().Element("label").AddCss(Inline ? GetAttribute("type") + "-inline" : GetAttribute("type")).Component;
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
