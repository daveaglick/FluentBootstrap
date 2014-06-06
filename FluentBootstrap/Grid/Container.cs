using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentBootstrap;

namespace FluentBootstrap.Grid
{
    public class Container : Tag
    {
        internal Container(BootstrapHelper helper) : base(helper, "div", "container")
        {
        }
    }
}
