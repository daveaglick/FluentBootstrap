using FluentBootstrap.Dropdowns;
using FluentBootstrap.Navs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navbars
{
    public interface INavbarCollapseCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class NavbarCollapseWrapper<THelper> : NavbarSectionWrapper<THelper>,
        INavbarNavCreator<THelper>,
        INavbarLinkCreator<THelper>,
        IDropdownCreator<THelper>,
        INavbarFormCreator<THelper>,
        INavbarButtonCreator<THelper>,
        INavbarTextCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface INavbarCollapse : INavbarSection
    {
    }

    public class NavbarCollapse<THelper> : NavbarSection<THelper, NavbarCollapse<THelper>, NavbarCollapseWrapper<THelper>>, INavbarCollapse
        where THelper : BootstrapHelper<THelper>
    {
        internal NavbarCollapse(IComponentCreator<THelper> creator)
            : base(creator, "div", Css.NavbarCollapse, Css.Collapse)
        {
        }
        
        protected override void OnStart(TextWriter writer)
        {
            // Get the Navbar ID and use it to set this id
            if (string.IsNullOrWhiteSpace(((ITag)this).GetAttribute("id")))
            {
                INavbar navbar = GetComponent<INavbar>();
                if (navbar != null)
                {
                    this.SetId(navbar.GetAttribute("id") + "-collapse");
                }
            }

            base.OnStart(writer);
        }
    }
}
