using FluentBootstrap.Dropdowns;
using FluentBootstrap.Navs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navbars
{
    public interface INavbarNavCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class NavbarNavWrapper<TModel> : TagWrapper<TModel>,
        INavbarLinkCreator<TModel>,
        IDropdownCreator<TModel>
    {
    }

    internal interface INavbarNav : ITag
    {
    }

    public class NavbarNav<TModel> : Tag<TModel, NavbarNav<TModel>, NavbarNavWrapper<TModel>>, INavbarNav, INavbarComponent
    {
        internal NavbarNav(IComponentCreator<TModel> creator)
            : base(creator, "div", Css.Nav, Css.NavbarNav, Css.NavbarLeft)
        {
        }
        
        protected override void OnStart(System.IO.TextWriter writer)
        {
            // Make sure we're in a collapse, but only if we're also in a navbar
            if (GetComponent<INavbar>() != null && GetComponent<INavbarCollapse>() == null)
            {
                new NavbarCollapse<TModel>(Helper).Start(writer);
            }

            base.OnStart(writer);
        }
    }
}
