using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navs
{
    public interface ITabsCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class TabsWrapper<TModel> : NavWrapper<TModel>
    {
    }


    internal interface ITabs : INav
    {
    }

    public class Tabs<TModel> : Nav<TModel, Tabs<TModel>, TabsWrapper<TModel>>, ITabs
    {
        internal Tabs(IComponentCreator<TModel> creator)
            : base(creator, Css.Nav, Css.NavTabs)
        {
            this.MergeAttribute("role", "tablist");
        }
    }
}
