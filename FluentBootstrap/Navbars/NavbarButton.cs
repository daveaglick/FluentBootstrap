using FluentBootstrap.Buttons;
using FluentBootstrap.Icons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navbars
{
    public interface INavbarButtonCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class NavbarButtonWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface INavbarButton : ITag
    {
    }

    public class NavbarButton<THelper> : Tag<THelper, NavbarButton<THelper>, NavbarButtonWrapper<THelper>>, 
        IButton, IHasIconExtensions, IHasButtonExtensions, IHasButtonStateExtensions, IHasDisabledAttribute, IHasTextContent, IHasValueAttribute, INavbarComponent
        where THelper : BootstrapHelper<THelper>
    {
        internal NavbarButton(IComponentCreator<THelper> creator)
            : base(creator, "button", Css.Btn, Css.BtnDefault, Css.NavbarBtn, Css.NavbarLeft)
        {
            MergeAttribute("type", "button");
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
