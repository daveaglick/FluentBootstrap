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

        internal CheckedControl(IComponentCreator creator, string type)
            : base(creator, "input")
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
                AddChild(Config.Content(Description));
            }

            // Add the wrapper
            if (!Inline)
            {
                _wrapper = Config.Element("div").AddCss(GetAttribute("type")).Component;
                _wrapper.Start(writer);
            }

            // Add the label wrapper
            if (!SuppressLabelWrapper)
            {
                _label = Config.Element("label").AddCss(Inline ? GetAttribute("type") + "-inline" : GetAttribute("type")).Component;
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
