using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class FormGroup : Tag
    {
        // This helps track if a label was written as part of this group so following inputs can adjust offset CSS classes accordingly
        internal bool WroteLabel { get; set; }

        internal FormGroup(BootstrapHelper helper) : base(helper, "div", "form-group")
        {
        }
    }
}
