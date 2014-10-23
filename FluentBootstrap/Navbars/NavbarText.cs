using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navbars
{
    public interface INavbarTextCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class NavbarTextWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface INavbarText : ITag
    {
    }

    public class NavbarText<TModel> : Tag<TModel, NavbarText<TModel>, NavbarTextWrapper<TModel>>, INavbarComponent, IHasTextAttribute
    {
        internal NavbarText(IComponentCreator<TModel> creator)
            : base(creator, "p", Css.NavbarText, Css.NavbarLeft)
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
