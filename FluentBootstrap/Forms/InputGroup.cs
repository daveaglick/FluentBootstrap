using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class InputGroup : Tag,
        ICanCreate<InputGroupAddon>,
        ICanCreate<InputGroupButton>
    {
        internal InputGroup(BootstrapHelper helper)
            : base(helper, "div", Css.InputGroup)
        {
        }
    }
}
