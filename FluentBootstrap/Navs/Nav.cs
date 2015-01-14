using FluentBootstrap.Dropdowns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navs
{
    public abstract class Nav : Tag,
        ICanCreate<Dropdown>
    {
        protected Nav(BootstrapHelper helper, params string[] cssClasses)
            : base(helper, "ul", cssClasses)
        {
        }
    }
}
