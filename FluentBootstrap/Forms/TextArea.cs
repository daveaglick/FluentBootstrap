using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class TextArea : FormControl
    {
        internal string Value { get; set; }

        internal TextArea(BootstrapHelper helper)
            : base(helper, "textarea", "form-control")
        {
        }

        protected override void Prepare(System.IO.TextWriter writer)
        {
            base.Prepare(writer);

            // Add the value as child content
            if (!string.IsNullOrEmpty(Value))
            {
                this.AddChild(new Content(Helper, Value));
            }
        }
    }
}
