using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentBootstrap.Forms
{
    public class CheckedControl : FormControl, IHasValueAttribute
    {
        internal bool Inline { get; set; }
        internal string Description { get; set; }

        internal CheckedControl(BootstrapHelper helper, string type) : base(helper, "input")
        {
            MergeAttribute("type", type);
        }

        protected override void Prepare(TextWriter writer)
        {
            base.Prepare(writer);

            // Add the description as child content
            if (!string.IsNullOrEmpty(Description))
            {
                this.AddChild(new Content(Helper, Description));
            }
        }

        protected override void OnStart(TextWriter writer)
        {
            // Add the wrapper div
            if (!Inline)
            {
                TagBuilder div = new TagBuilder("div");
                div.AddCssClass(TagBuilder.Attributes["type"]);
                writer.Write(div.ToString(TagRenderMode.StartTag));
            }

            // Add the wrapper label
            TagBuilder label = new TagBuilder("label");
            if (Inline)
            {
                label.AddCssClass(TagBuilder.Attributes["type"] + "-inline");
            }
            writer.Write(label.ToString(TagRenderMode.StartTag));

            base.OnStart(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            base.OnFinish(writer);

            // Close the wrappers
            TagBuilder label = new TagBuilder("label");
            writer.Write(label.ToString(TagRenderMode.EndTag));
            if (!Inline)
            {
                TagBuilder div = new TagBuilder("div");
                writer.Write(div.ToString(TagRenderMode.EndTag));
            }
        }

        public interface ICreate : ICreateComponent
        {
        }
    }
}
