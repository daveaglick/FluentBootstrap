using FluentBootstrap.Badges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navs
{
    public class Pill : NavLink,
        ICanCreate<Badge>
    {
        internal Pill(BootstrapHelper helper)
            : base(helper)
        {
        }
    }
}
