using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentBootstrap;

namespace FluentBootstrap.Grids
{
    public interface IContainerCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class ContainerWrapper<THelper> : TagWrapper<THelper>, IGridRowCreator<THelper>
    {
    }

    internal interface IContainer : ITag
    {
    }

    public class Container<THelper> : Tag<THelper, Container<THelper>, ContainerWrapper<THelper>>, IContainer
    {
        internal Container(IComponentCreator<THelper> creator)
            : base(creator, "div", Css.Container)
        {
        }
    }
}
