using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class Static : FormControl
    {
        public interface ICreate : ICreateComponent
        {
        }

        internal string Value { get; set; }

        internal Static(BootstrapHelper helper) : base(helper, "p", "form-control-static")
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
