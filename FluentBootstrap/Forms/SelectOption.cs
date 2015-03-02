using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FluentBootstrap.Forms
{
    public class SelectOption : Tag, IHasTextContent
    {
        public bool Selected { get; set; }
        public string Value { get; set; }

        internal SelectOption(BootstrapHelper helper)
            : base(helper, "option")
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            if (Value != null)
            {
                MergeAttribute("value", Value);
            }

            if (Selected)
            {
                MergeAttribute("selected", "selected");
            }

            base.OnStart(writer);
        }
    }
}
