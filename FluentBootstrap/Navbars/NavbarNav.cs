using FluentBootstrap.Dropdowns;
using FluentBootstrap.Navs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navbars
{
    public class NavbarNav : Tag, INavbarComponent,
        ICanCreate<NavbarLink>,
        ICanCreate<Dropdown>
    {
        internal NavbarNav(BootstrapHelper helper)
            : base(helper, "div", Css.Nav, Css.NavbarNav, Css.NavbarLeft)
        {
        }
        
        protected override void OnStart(System.IO.TextWriter writer)
        {
            // Make sure we're in a collapse, but only if we're also in a navbar
            if (GetComponent<Navbar>() != null && GetComponent<NavbarCollapse>() == null)
            {
                GetHelper().NavbarCollapse().Component.Start(writer);
            }

            base.OnStart(writer);
        }
    }
}
