using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public class DescriptionTerm : Tag
    {
        internal DescriptionTerm(BootstrapHelper helper)
            : base(helper, "dt")
        {
        }
    }
}
