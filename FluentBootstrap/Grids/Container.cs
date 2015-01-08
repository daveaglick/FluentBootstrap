using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentBootstrap;

namespace FluentBootstrap.Grids
{
    public class Container : Tag,
        ICanCreate<GridRow>
    {
        internal Container(IComponentCreator creator)
            : base(creator, "div", Css.Container)
        {
        }
    }
}
