using FluentBootstrap.Dropdowns;
using FluentBootstrap.Grids;
using FluentBootstrap.Navs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navbars
{
    public interface INavbarCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class NavbarWrapper<THelper> : TagWrapper<THelper>,
        INavbarHeaderCreator<THelper>,
        INavbarCollapseCreator<THelper>,
        INavbarToggleCreator<THelper>,
        IBrandCreator<THelper>,
        INavbarNavCreator<THelper>,
        INavbarLinkCreator<THelper>,
        IDropdownCreator<THelper>,
        INavbarFormCreator<THelper>,
        INavbarButtonCreator<THelper>,
        INavbarTextCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface INavbar : ITag
    {
        bool HasHeader { get; set; }
    }

    public class Navbar<THelper> : Tag<THelper, Navbar<THelper>, NavbarWrapper<THelper>>, INavbar
        where THelper : BootstrapHelper<THelper>
    {
        bool INavbar.HasHeader { get; set; }
        internal bool Fluid { get; set; }
        private Container<THelper> _container;

        internal Navbar(IComponentCreator<THelper> creator)
            : base(creator, "nav", Css.Navbar, Css.NavbarDefault)
        {
            this.MergeAttribute("role", "navigation");
            this.SetId("navbar");
        }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);

            _container = Helper.Container().SetFluid(Fluid);
            _container.Start(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            if (!((INavbar)this).HasHeader)
            {
                new NavbarHeader<THelper>(Helper).StartAndFinish(writer);
            }

            _container.Finish(writer);

            base.OnFinish(writer);
        }
    }
}
