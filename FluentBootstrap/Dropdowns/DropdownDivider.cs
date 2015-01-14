using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Dropdowns
{
    public class DropdownDivider : Tag
    {
        internal DropdownDivider(BootstrapHelper hepler)
            : base(hepler, "li", Css.Divider)
        {
            MergeAttribute("role", "presentation");
        }
    }
}
