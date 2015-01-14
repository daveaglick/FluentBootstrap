using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public class ListItem : Tag
    {
        internal ListItem(BootstrapHelper helper)
            : base(helper, "li")
        {
        }
    }
}
