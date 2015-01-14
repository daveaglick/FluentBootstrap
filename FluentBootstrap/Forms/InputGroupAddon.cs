using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class InputGroupAddon : Tag
    {
        internal InputGroupAddon(BootstrapHelper helper)
            : base(helper, "span", Css.InputGroupAddon)
        {
        }
    }
}
