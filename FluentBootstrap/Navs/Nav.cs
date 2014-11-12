using FluentBootstrap.Dropdowns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navs
{
    public interface INavCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class NavWrapper<THelper> : TagWrapper<THelper>,
        IDropdownCreator<THelper>
    {
    }

    internal interface INav : ITag
    {
    }

    public abstract class Nav<THelper, TThis, TWrapper> : Tag<THelper, TThis, TWrapper>, INav
        where TThis : Nav<THelper, TThis, TWrapper>
        where TWrapper : NavWrapper<THelper>, new()
    {
        protected Nav(IComponentCreator<THelper> creator, params string[] cssClasses)
            : base(creator, "ul", cssClasses)
        {
        }
    }
}
