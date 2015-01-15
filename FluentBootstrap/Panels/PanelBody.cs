using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    public class PanelBody : PanelSection
    {
        internal PanelBody(BootstrapHelper helper)
            : base(helper, Css.PanelBody)
        {
        }
    }
}
