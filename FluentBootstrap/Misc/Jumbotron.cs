using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Misc
{
    public class Jumbotron : Tag
    {
        internal Jumbotron(BootstrapHelper helper)
            : base(helper, "div", Css.Jumbotron)
        {
        }
    }
}
