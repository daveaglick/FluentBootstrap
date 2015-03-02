using FluentBootstrap.Alerts;
using FluentBootstrap.Badges;
using FluentBootstrap.Forms;
using FluentBootstrap.Icons;
using FluentBootstrap.Navbars;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Links
{
    public class Link : Tag, IHasIconExtensions, IHasLinkExtensions, IHasTextContent,
        ICanCreate<Badge>
    {
        internal Link(BootstrapHelper helper)
            : base(helper, "a")
        {
            PrettyPrint = false;
        }

        protected override void OnStart(TextWriter writer)
        {
            // Adjust the link style if we're in a navbar
            if(GetComponent<Navbar>() != null)
            {
                CssClasses.Add(Css.NavbarLink);
            }

            // Adjust the link style if we're in an alert
            if(GetComponent<Alert>() != null)
            {
                CssClasses.Add(Css.AlertLink);
            }

            base.OnStart(writer);
        }
    }
}
