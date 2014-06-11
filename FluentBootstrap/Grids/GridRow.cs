using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Grids
{
    public class GridRow : Tag,
        GridColumn.ICreate
    {
        public interface ICreate : ICreateComponent
        {
        }

        internal GridRow(BootstrapHelper helper) : base(helper, "div", "row")
        {
        }
    }
}
