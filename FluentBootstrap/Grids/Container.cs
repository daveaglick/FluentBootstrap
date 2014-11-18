using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentBootstrap;

namespace FluentBootstrap.Grids
{
    public interface IContainerCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class ContainerWrapper<THelper> : TagWrapper<THelper>, IGridRowCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IContainer : ITag
    {
    }

    public class Container<THelper> : Tag<THelper, Container<THelper>, ContainerWrapper<THelper>>, IContainer
        where THelper : BootstrapHelper<THelper>
    {
        internal Container(IComponentCreator<THelper> creator)
            : base(creator, "div", Css.Container)
        {
        }
    }
}
