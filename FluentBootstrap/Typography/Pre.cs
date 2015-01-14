using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public class Pre : Tag, IHasTextContent
    {
        internal Pre(BootstrapHelper helper)
            : base(helper, "pre")
        {
        }
    }
}
