using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navbars
{
    public abstract class NavbarSection : Tag
    {
        protected NavbarSection(BootstrapHelper helper, string tagName, params string[] cssClasses)
            : base(helper, tagName, cssClasses)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Exit any existing navbar sections
            Pop<NavbarSection>(writer);

            base.OnStart(writer);
        }
    }
}
