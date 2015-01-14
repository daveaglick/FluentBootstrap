using FluentBootstrap.Buttons;
using FluentBootstrap.Dropdowns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class InputGroupButton : Tag,
        ICanCreate<Button>,
        ICanCreate<Dropdown>
    {
        internal InputGroupButton(BootstrapHelper helper)
            : base(helper, "span", Css.InputGroupBtn)
        {
        }
    }
}
