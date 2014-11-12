using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navs
{
    public interface ITabCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class TabWrapper<THelper> : NavLinkWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface ITab : INavLink
    {
    }

    public class Tab<THelper> : NavLink<THelper, Tab<THelper>, TabWrapper<THelper>>, ITab
        where THelper : BootstrapHelper<THelper>
    {
        internal Tab(IComponentCreator<THelper> creator)
            : base(creator)
        {
        }
    }
}
