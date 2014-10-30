using FluentBootstrap.Badges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navs
{
    public interface IPillCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class PillWrapper<TModel> : NavLinkWrapper<TModel>,
        IBadgeCreator<TModel>
    {
    }

    internal interface IPill : INavLink
    {
    }

    public class Pill<TModel> : NavLink<TModel, Pill<TModel>, PillWrapper<TModel>>, IPill
    {
        internal Pill(IComponentCreator<TModel> creator)
            : base(creator)
        {
        }
    }
}
