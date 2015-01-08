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
        public GridRow(IComponentCreator creator)
            : base(creator, "div", Css.Row)
        {
        }
    }
}
