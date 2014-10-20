using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentBootstrap.Forms
{
    public interface ICheckedControlCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class CheckedControlWrapper<TModel> : FormControlWrapper<TModel>
    {
    }

    internal interface ICheckedControl : IFormControl
    {
    }

    public class CheckedControl<TModel> : FormControl<TModel, CheckedControl<TModel>, CheckedControlWrapper<TModel>>, ICheckedControl, IHasValueAttribute, IHasNameAttribute
    {
        internal bool Inline { get; set; }
        internal string Description { get; set; }
        internal bool SuppressLabelWrapper { get; set; }

        private Element<TModel> _wrapper = null;
        private Element<TModel> _label = null;

        internal CheckedControl(IComponentCreator<TModel> creator, string type)
            : base(creator, "input")
        {
            MergeAttribute("type", type);
        }

        protected override void PreStart(TextWriter writer)
        {
            base.PreStart(writer);

            // Add the description as child content
            if (!string.IsNullOrEmpty(Description))
            {
                this.AddChild(new Content<TModel>(Helper, Description));
            }

            // Add the wrapper
            if (!Inline)
            {
                _wrapper = new Element<TModel>(Helper, "div", TagBuilder.Attributes["type"]);
                _wrapper.Start(writer, true);
            }

            // Add the label wrapper
            if (!SuppressLabelWrapper)
            {
                _label = new Element<TModel>(Helper, "label", Inline ? TagBuilder.Attributes["type"] + "-inline" : TagBuilder.Attributes["type"]);
                _label.Start(writer, true);
            }
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

        protected override bool OutputEndTag
        {
            get { return false; }
        }
    }
}
