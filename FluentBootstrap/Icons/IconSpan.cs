using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Icons
{
    public class IconSpan : Tag
    {
        internal IconSpan(BootstrapHelper helper, Icon icon)
            : base(helper, "span", Css.Glyphicon, icon.GetDescription())
        {
        }
    }
}
