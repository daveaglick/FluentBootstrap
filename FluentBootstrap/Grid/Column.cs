using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Grid
{
    public class Column : BootstrapComponent, IColumn
    {
        internal Column(BootstrapHelper helper) : base("div", helper)
        {
        }
    }
}
