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
    public interface INavbarButtonCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class NavbarButtonWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface INavbarButton : ITag
    {
    }

    public class NavbarButton<TModel> : Tag<TModel, NavbarButton<TModel>, NavbarButtonWrapper<TModel>>, 
        IButton, IHasIconExtensions, IHasButtonExtensions, IHasButtonStateExtensions, IHasDisabledAttribute, IHasTextAttribute, IHasValueAttribute, INavbarComponent
    {
        internal NavbarButton(IComponentCreator<TModel> creator)
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
                    new NavbarCollapse<TModel>(Helper).Start(writer);
                }
            }

            base.OnStart(writer);
        }
    }
}
