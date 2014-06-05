using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentBootstrap;

namespace FluentBootstrap.Grid
{
    public class Container : BootstrapComponent
    {
        internal Container(BootstrapHelper helper) : base("div", helper, "container") 
        {
        }
    }
}
