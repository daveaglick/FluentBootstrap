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

    public class NavbarNavWrapper<TModel> : NavWrapper<TModel>
    {
    }

    internal interface INavbarNav : INav
    {
    }

    public class NavbarNav<TModel> : Nav<TModel, NavbarNav<TModel>, NavbarNavWrapper<TModel>>, INavbarNav
    {
        internal NavbarNav(IComponentCreator<TModel> creator)
            : base(creator, Css.Nav, Css.NavbarNav)
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
