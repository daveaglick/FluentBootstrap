using FluentBootstrap.Dropdowns;
using FluentBootstrap.Navs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navbars
{
    public interface INavbarNavCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class NavbarNavWrapper<THelper> : TagWrapper<THelper>,
        INavbarLinkCreator<THelper>,
        IDropdownCreator<THelper>
    {
    }

    internal interface INavbarNav : ITag
    {
    }

    public class NavbarNav<THelper> : Tag<THelper, NavbarNav<THelper>, NavbarNavWrapper<THelper>>, INavbarNav, INavbarComponent
    {
        internal NavbarNav(IComponentCreator<THelper> creator)
            : base(creator, "div", Css.Nav, Css.NavbarNav, Css.NavbarLeft)
        {
        }
        
        protected override void OnStart(System.IO.TextWriter writer)
        {
            // Make sure we're in a collapse, but only if we're also in a navbar
            if (GetComponent<INavbar>() != null && GetComponent<INavbarCollapse>() == null)
            {
                new NavbarCollapse<THelper>(Helper).Start(writer);
            }

            base.OnStart(writer);
        }
    }
}
