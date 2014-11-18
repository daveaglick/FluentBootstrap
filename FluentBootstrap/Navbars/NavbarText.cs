using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navbars
{
    public interface INavbarTextCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class NavbarTextWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface INavbarText : ITag
    {
    }

    public class NavbarText<THelper> : Tag<THelper, NavbarText<THelper>, NavbarTextWrapper<THelper>>, INavbarComponent, IHasTextContent
        where THelper : BootstrapHelper<THelper>
    {
        internal NavbarText(IComponentCreator<THelper> creator)
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
                    new NavbarCollapse<THelper>(Helper).Start(writer);
                }
            }

            base.OnStart(writer);
        }
    }
}
