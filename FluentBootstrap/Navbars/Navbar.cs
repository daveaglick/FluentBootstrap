using FluentBootstrap.Grids;
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

    public class NavbarWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface INavbar : ITag
    {
    }

    public class Navbar<TModel> : Tag<TModel, Navbar<TModel>, NavbarWrapper<TModel>>, INavbar
    {
        internal bool Fluid { private get; set; }
        private Container<TModel> _container;

        internal Navbar(IComponentCreator<TModel> creator)
            : base(creator, "nav", Css.Navbar, Css.NavbarDefault)
        {
            this.MergeAttribute("role", "navigation");
        }

        protected override void OnPrepare(TextWriter writer)
        {
            _container = Helper.Container().SetFluid(Fluid);

            base.OnPrepare(writer);
        }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);
            _container.Start(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            _container.Finish(writer);
            base.OnFinish(writer);
        }
    }
}
