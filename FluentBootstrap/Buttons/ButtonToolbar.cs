using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Buttons
{
    public class ButtonToolbar : Tag,
        ICanCreate<ButtonGroup>
    {
        internal ButtonToolbar(BootstrapHelper helper)
            : base(helper, "div", Css.BtnToolbar)
        {
            MergeAttribute("role", "toolbar");
        }
    }
}
