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
    internal interface ICheckedControl : IFormControl
    {
    }

    public class CheckedControl<TModel> : FormControl<TModel, CheckedControl<TModel>>, ICheckedControl, IHasValueAttribute, IHasNameAttribute
    {
        internal bool Inline { get; set; }
        internal string Description { get; set; }

        private Element<TModel> _wrapper = null;
        private Element<TModel> _label = null;

        internal CheckedControl(BootstrapHelper<TModel> helper, string type)
            : base(helper, "input")
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

            // Add the label
            _label = new Element<TModel>(Helper, "label", Inline ? TagBuilder.Attributes["type"] + "-inline" : TagBuilder.Attributes["type"]);
            _label.Start(writer, true);
        }

        protected override void OnFinish(TextWriter writer)
        {
            base.OnFinish(writer);

            // Finish the wrapper and label
            _label.Finish(writer);
            if (_wrapper != null)
            {
                _wrapper.Finish(writer);
            }
        }
    }
}
