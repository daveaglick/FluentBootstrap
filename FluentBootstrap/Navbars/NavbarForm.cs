using FluentBootstrap.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navbars
{
    public interface INavbarFormCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class NavbarFormWrapper<TModel> : FormWrapper<TModel>
    {
    }

    internal interface INavbarForm : IForm
    {
    }

    public class NavbarForm<TModel> : Form<TModel, NavbarForm<TModel>, NavbarFormWrapper<TModel>>, INavbarForm, INavbarComponent
    {
        internal NavbarForm(IComponentCreator<TModel> creator)
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
                    new NavbarCollapse<TModel>(Helper).Start(writer);
                }
            }

            base.OnStart(writer);
        }
    }
}
