using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navs
{
    public class Tabs : Nav,
        ICanCreate<Tab>
    {
        internal Tabs(BootstrapHelper helper)
            : base(helper, Css.Nav, Css.NavTabs)
        {
            MergeAttribute("role", "tablist");
        }
    }
}
