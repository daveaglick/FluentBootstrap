using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class Label : Tag, FluentBootstrap.Grids.IGridColumn
    {
        internal Label(BootstrapHelper helper, string label) : base(helper, "label", "control-label")
        {
            AddChild(new Content(helper, label));
        }
    }
}
