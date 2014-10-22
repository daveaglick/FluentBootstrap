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
    public interface INavbarHeaderCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class NavbarHeaderWrapper<TModel> : NavbarSectionWrapper<TModel>,
        INavbarToggleCreator<TModel>,
        IBrandCreator<TModel>
    {
    }

    internal interface INavbarHeader : INavbarSection
    {
        bool HasToggle { get; set; }
    }

    public class NavbarHeader<TModel> : NavbarSection<TModel, NavbarHeader<TModel>, NavbarHeaderWrapper<TModel>>, INavbarHeader
    {
        bool INavbarHeader.HasToggle { get; set; }

        internal NavbarHeader(IComponentCreator<TModel> creator)
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
                new NavbarToggle<TModel>(Helper).StartAndFinish(writer);
            }

            base.OnFinish(writer);
        }
    }
}
