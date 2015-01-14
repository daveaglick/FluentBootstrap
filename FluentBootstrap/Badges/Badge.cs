using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Badges
{
    public class Badge : Tag, IHasTextContent
    {
        internal Badge(BootstrapHelper helper)
            : base(helper, "span", Css.Badge)
        {
        }
    }
}
