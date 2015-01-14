using FluentBootstrap.Badges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navs
{
    public class Pills : Nav,
        ICanCreate<Pill>
    {
        internal Pills(BootstrapHelper helper)
            : base(helper, Css.Nav, Css.NavPills)
        {
        }
    }
}
