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
    public interface INavbarCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class NavbarWrapper<TModel> : TagWrapper<TModel>,
        INavbarHeaderCreator<TModel>,
        INavbarCollapseCreator<TModel>,
        INavbarToggleCreator<TModel>,
        IBrandCreator<TModel>,
        INavbarNavCreator<TModel>,
        INavLinkCreator<TModel>,
        IDropdownCreator<TModel>,
        INavbarFormCreator<TModel>,
        INavbarButtonCreator<TModel>,
        INavbarTextCreator<TModel>
    {
    }

    internal interface INavbar : ITag
    {
        bool HasHeader { get; set; }
    }

    public class Navbar<TModel> : Tag<TModel, Navbar<TModel>, NavbarWrapper<TModel>>, INavbar
    {
        bool INavbar.HasHeader { get; set; }
        internal bool Fluid { private get; set; }
        private Container<TModel> _container;

        internal Navbar(IComponentCreator<TModel> creator)
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
                new NavbarHeader<TModel>(Helper).StartAndFinish(writer);
            }

            _container.Finish(writer);

            base.OnFinish(writer);
        }
    }
}
