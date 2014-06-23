using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentBootstrap.Forms
{
    public interface ICheckedControl : IFormControl
    {
    }

    public class CheckedControl<TModel> : FormControl<TModel, CheckedControl<TModel>>, ICheckedControl, IHasValueAttribute, IHasNameAttribute
    {
        internal bool Inline { get; set; }
        internal string Description { get; set; }

        private Tag<TModel> _wrapper = null;
        private Tag<TModel> _label = null;

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
                _wrapper = new Tag<TModel>(Helper, "div", TagBuilder.Attributes["type"]);
                _wrapper.Start(writer, true);
            }

            // Add the label
            _label = new Tag<TModel>(Helper, "label", Inline ? TagBuilder.Attributes["type"] + "-inline" : null);
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
