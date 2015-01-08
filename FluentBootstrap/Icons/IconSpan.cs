using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Icons
{
    public class IconSpan : Tag
    {
        internal IconSpan(IComponentCreator creator, Icon icon)
            : base(creator, "span", Css.Glyphicon, icon.GetDescription())
        {
        }
    }
}
