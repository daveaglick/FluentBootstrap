using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public class Blockquote : Tag
    {
        internal Blockquote(BootstrapHelper helper)
            : base(helper, "blockquote")
        {
        }

        internal string Quote { get; set; }
        internal string Footer { get; set; }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);

            if (!string.IsNullOrWhiteSpace(Quote))
            {
                GetHelper().Element("p").SetText(Quote).Component.StartAndFinish(writer);
            }

            if (!string.IsNullOrWhiteSpace(Footer))
            {
                GetHelper().Element("footer").SetText(Footer).Component.StartAndFinish(writer);
            }
        }
    }
}
