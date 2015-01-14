using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public class DescriptionList : Tag,
        ICanCreate<Description>,
        ICanCreate<DescriptionTerm>
    {
        internal DescriptionList(BootstrapHelper helper)
            : base(helper, "dl")
        {
        }
    }
}
