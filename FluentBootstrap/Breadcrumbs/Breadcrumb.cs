using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Breadcrumbs
{
    public class Breadcrumb : Tag,
        ICanCreate<Crumb>
    {
        internal Breadcrumb(BootstrapHelper helper)
            : base(helper, "ol", Css.Breadcrumb)
        {
        }
    }
}
