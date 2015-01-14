using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public class Description : Tag
    {
        internal Description(BootstrapHelper helper)
            : base(helper, "dd")
        {
        }
    }
}
