using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Wells
{
    public class Well : Tag
    {
        internal Well(BootstrapHelper helper)
            : base(helper, "div", Css.Well)
        {
        }
    }
}
