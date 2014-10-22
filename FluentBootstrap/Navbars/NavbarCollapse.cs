using FluentBootstrap.Dropdowns;
using FluentBootstrap.Navs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navbars
{
    public interface INavbarCollapseCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class NavbarCollapseWrapper<TModel> : NavbarSectionWrapper<TModel>,
        INavbarNavCreator<TModel>,
        INavLinkCreator<TModel>,
        IDropdownCreator<TModel>
    {
    }

    internal interface INavbarCollapse : INavbarSection
    {
    }

    public class NavbarCollapse<TModel> : NavbarSection<TModel, NavbarCollapse<TModel>, NavbarCollapseWrapper<TModel>>, INavbarCollapse
    {
        internal NavbarCollapse(IComponentCreator<TModel> creator)
            : base(creator, "div", Css.NavbarCollapse, Css.Collapse)
        {
        }

        protected override void OnPrepare(System.IO.TextWriter writer)
        {
            base.OnPrepare(writer);

            // Get the Navbar ID and use it to set this id
            if (string.IsNullOrWhiteSpace(((ITag)this).GetAttribute("id")))
            {
                INavbar navbar = GetComponent<INavbar>();
                if (navbar != null)
                {
                    this.SetId(navbar.GetAttribute("id") + "-collapse");
                }
            }
        }
    }
}
