using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    public abstract class PanelSection : Tag
    {
        protected PanelSection(BootstrapHelper helper, params string[] cssClasses)
            : base(helper, "div", cssClasses)
        {
        }
        
        protected override void OnStart(TextWriter writer)
        {
            Pop<PanelSection>(writer);

            base.OnStart(writer);
        }
    }
}
