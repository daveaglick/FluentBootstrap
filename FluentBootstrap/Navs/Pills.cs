using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navs
{
    public interface IPillsCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class PillsWrapper<TModel> : NavWrapper<TModel>
    {
    }


    internal interface IPills : INav
    {
    }

    public class Pills<TModel> : Nav<TModel, Pills<TModel>, PillsWrapper<TModel>>, IPills
    {
        internal Pills(IComponentCreator<TModel> creator)
            : base(creator, Css.Nav, Css.NavPills)
        {
        }
    }
}
