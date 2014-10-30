using FluentBootstrap.Dropdowns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Navs
{
    public interface INavCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class NavWrapper<TModel> : TagWrapper<TModel>,
        IDropdownCreator<TModel>
    {
    }

    internal interface INav : ITag
    {
    }

    public abstract class Nav<TModel, TThis, TWrapper> : Tag<TModel, TThis, TWrapper>, INav
        where TThis : Nav<TModel, TThis, TWrapper>
        where TWrapper : NavWrapper<TModel>, new()
    {
        protected Nav(IComponentCreator<TModel> creator, params string[] cssClasses)
            : base(creator, "ul", cssClasses)
        {
        }
    }
}
