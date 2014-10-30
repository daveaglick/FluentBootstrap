using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navs
{
    public interface ITabCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class TabWrapper<TModel> : NavLinkWrapper<TModel>
    {
    }

    internal interface ITab : INavLink
    {
    }

    public class Tab<TModel> : NavLink<TModel, Tab<TModel>, TabWrapper<TModel>>, ITab
    {
        internal Tab(IComponentCreator<TModel> creator)
            : base(creator)
        {
        }
    }
}
