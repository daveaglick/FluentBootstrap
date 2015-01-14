using FluentBootstrap.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navbars
{
    public class NavbarForm : Form, INavbarComponent
    {
        internal NavbarForm(BootstrapHelper helper)
            : base(helper, Css.NavbarForm, Css.NavbarLeft)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // See if we're in a navbar
            if (GetComponent<Navbar>() != null)
            {
                // Make sure we're not in a NavbarNav (close it if we are)
                Pop<NavbarNav>(writer);

                // Make sure we're in a collapse
                if (GetComponent<NavbarCollapse>() == null)
                {
                    GetHelper().NavbarCollapse().Component.Start(writer);
                }
            }

            base.OnStart(writer);
        }
    }
}
