using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Grids
{
    public class Row : Tag
    {
        internal Row(BootstrapHelper helper) : base(helper, "div", "row")
        {
        }
    }
}
