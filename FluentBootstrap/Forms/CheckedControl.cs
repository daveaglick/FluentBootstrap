using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface ICheckedControlCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class CheckedControlWrapper<THelper> : FormControlWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface ICheckedControl : IFormControl
    {
    }

    public class CheckedControl<THelper> : FormControl<THelper, CheckedControl<THelper>, CheckedControlWrapper<THelper>>, ICheckedControl, IHasValueAttribute, IHasNameAttribute
        where THelper : BootstrapHelper<THelper>
    {
        internal bool Inline { get; set; }
        internal string Description { get; set; }
        internal bool SuppressLabelWrapper { get; set; }

        private Element<THelper> _wrapper = null;
        private Element<THelper> _label = null;

        internal CheckedControl(IComponentCreator<THelper> creator, string type)
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
                this.AddChild(new Content<THelper>(Helper, Description));
            }

            // Add the wrapper
            if (!Inline)
            {
                _wrapper = new Element<THelper>(Helper, "div").AddCss(GetAttribute("type"));
                _wrapper.Start(writer);
            }

            // Add the label wrapper
            if (!SuppressLabelWrapper)
            {
                _label = new Element<THelper>(Helper, "label").AddCss(Inline ? GetAttribute("type") + "-inline" : GetAttribute("type"));
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
