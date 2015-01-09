using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Grids
{
    public class GridRow : Tag,
        ICanCreate<GridColumn>
    {
        internal GridRow(BootstrapHelper helper)
            : base(helper, "div", Css.Row)
        {
        }
    }
}
