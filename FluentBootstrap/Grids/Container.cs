using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentBootstrap;

namespace FluentBootstrap.Grids
{
    public class Container : Tag,
        GridRow.ICreate
    {
        internal Container(BootstrapHelper helper) : base(helper, "div", "container")
        {
        }

        public interface ICreate : ICreateComponent
        {
        }
    }
}
