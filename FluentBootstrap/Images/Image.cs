using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Images
{
    public class Image : Tag
    {
        internal Image(BootstrapHelper helper)
            : base(helper, "img")
        {
        }

        protected override bool OutputEndTag
        {
            get { return false; }
        }
    }
}
