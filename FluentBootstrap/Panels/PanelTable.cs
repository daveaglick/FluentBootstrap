using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    public class PanelTable : PanelSection
    {
        internal PanelTable(BootstrapHelper helper)
            : base(helper, Css.Table)
        {
        }
    }
}
