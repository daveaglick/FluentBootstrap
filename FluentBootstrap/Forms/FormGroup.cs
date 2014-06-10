using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class FormGroup : Tag
    {
        internal FormGroup(BootstrapHelper helper) : base(helper, "div", "form-group")
        {
        }
    }
}
