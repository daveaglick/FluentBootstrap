using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Thumbnails
{
    public class Caption : Tag
    {
        internal Caption(BootstrapHelper helper)
            : base(helper, "div", Css.Caption)
        {
        }
    }
}
