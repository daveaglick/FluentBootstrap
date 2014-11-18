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
    public interface INavbarHeaderCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class NavbarHeaderWrapper<THelper> : NavbarSectionWrapper<THelper>,
        INavbarToggleCreator<THelper>,
        IBrandCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface INavbarHeader : INavbarSection
    {
        bool HasToggle { get; set; }
    }

    public class NavbarHeader<THelper> : NavbarSection<THelper, NavbarHeader<THelper>, NavbarHeaderWrapper<THelper>>, INavbarHeader
        where THelper : BootstrapHelper<THelper>
    {
        bool INavbarHeader.HasToggle { get; set; }

        internal NavbarHeader(IComponentCreator<THelper> creator)
            : base(creator, "div", Css.NavbarHeader)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            INavbar navbar = GetComponent<INavbar>();
            if (navbar != null)
            {
                navbar.HasHeader = true;
            }

            base.OnStart(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            if(!((INavbarHeader)this).HasToggle)
            {
                new NavbarToggle<THelper>(Helper).StartAndFinish(writer);
            }

            base.OnFinish(writer);
        }
    }
}
