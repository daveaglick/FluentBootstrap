using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Grids
{
    public class Column : Tag, IColumn
    {
        internal Column(BootstrapHelper helper) : base(helper, "div")
        {
        }
    }
}
