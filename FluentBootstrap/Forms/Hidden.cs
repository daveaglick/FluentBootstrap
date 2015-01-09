using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class Hidden : Tag, IHasValueAttribute
    {
        internal Hidden(BootstrapHelper helper)
            : base(helper, "input")
        {
            MergeAttribute("type", "hidden");
        }
    }
}
