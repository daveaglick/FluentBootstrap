using FluentBootstrap.Badges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navs
{
    public interface IPillsCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class PillsWrapper<THelper> : NavWrapper<THelper>,
        IPillCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }


    internal interface IPills : INav
    {
    }

    public class Pills<THelper> : Nav<THelper, Pills<THelper>, PillsWrapper<THelper>>, IPills
        where THelper : BootstrapHelper<THelper>
    {
        internal Pills(IComponentCreator<THelper> creator)
            : base(creator, Css.Nav, Css.NavPills)
        {
        }
    }
}
