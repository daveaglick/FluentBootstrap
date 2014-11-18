using FluentBootstrap.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navbars
{
    public interface INavbarFormCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class NavbarFormWrapper<THelper> : FormWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface INavbarForm : IForm
    {
    }

    public class NavbarForm<THelper> : Form<THelper, NavbarForm<THelper>, NavbarFormWrapper<THelper>>, INavbarForm, INavbarComponent
        where THelper : BootstrapHelper<THelper>
    {
        internal NavbarForm(IComponentCreator<THelper> creator)
            : base(creator, Css.NavbarForm, Css.NavbarLeft)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // See if we're in a navbar
            if (GetComponent<INavbar>() != null)
            {
                // Make sure we're not in a NavbarNav (close it if we are)
                Pop<INavbarNav>(writer);

                // Make sure we're in a collapse
                if (GetComponent<INavbarCollapse>() == null)
                {
                    new NavbarCollapse<THelper>(Helper).Start(writer);
                }
            }

            base.OnStart(writer);
        }
    }
}
