using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navbars
{
    public class NavbarToggle : Tag
    {
        public string DataTarget { get; set; }
        public bool Hamburger { get; set; }

        internal NavbarToggle(BootstrapHelper helper)
            : base(helper, "button", Css.NavbarToggle, "collapsed")
        {
            Hamburger = true;
            MergeAttribute("type", "button");
            MergeAttribute("data-toggle", "collapse");
        }
        
        protected override void OnStart(TextWriter writer)
        {
            // Set the data-target
            if (string.IsNullOrWhiteSpace(DataTarget))
            {
                // Get the Navbar ID and use it to set the data-target
                string navbarId = string.Empty;
                Navbar navbar = GetComponent<Navbar>();
                if (navbar != null)
                {
                    navbarId = navbar.GetAttribute("id");
                }
                DataTarget = "#" + navbarId + "-collapse";
            }
            MergeAttribute("data-target", DataTarget);

            // Make sure we're in a header, but only if we're also in a navbar
            NavbarHeader header = GetComponent<NavbarHeader>();
            if (GetComponent<Navbar>() != null && header == null)
            {
                GetHelper().NavbarHeader().Component.Start(writer);
            }
            else if(header != null)
            {
                header.HasToggle = true;
            }

            base.OnStart(writer);

            GetHelper().Span().AddCss(Css.SrOnly).SetText("Toggle Navigation").Component.StartAndFinish(writer);
            if (Hamburger)
            {
                GetHelper().Span().AddCss(Css.IconBar).Component.StartAndFinish(writer);
                GetHelper().Span().AddCss(Css.IconBar).Component.StartAndFinish(writer);
                GetHelper().Span().AddCss(Css.IconBar).Component.StartAndFinish(writer);
            }
        }
    }
}
