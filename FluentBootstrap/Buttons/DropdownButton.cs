using FluentBootstrap.Dropdowns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Buttons
{
    public class DropdownButton : Tag,
        ICanCreate<Button>,
        ICanCreate<LinkButton>,
        ICanCreate<Dropdown>
    {
        internal DropdownButton(BootstrapHelper helper)
            : base(helper, "div", Css.BtnGroup)
        {
        }
    }
}
