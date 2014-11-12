using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navs
{
    public interface ITabCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class TabWrapper<THelper> : NavLinkWrapper<THelper>
    {
    }

    internal interface ITab : INavLink
    {
    }

    public class Tab<THelper> : NavLink<THelper, Tab<THelper>, TabWrapper<THelper>>, ITab
    {
        internal Tab(IComponentCreator<THelper> creator)
            : base(creator)
        {
        }
    }
}
