using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentBootstrap;

namespace FluentBootstrap.Grids
{
    public interface IContainerCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class ContainerWrapper<TModel> : TagWrapper<TModel>, IGridRowCreator<TModel>
    {
    }

    internal interface IContainer : ITag
    {
    }

    public class Container<TModel> : Tag<TModel, Container<TModel>, ContainerWrapper<TModel>>, IContainer
    {
        internal Container(IComponentCreator<TModel> creator)
            : base(creator, "div", Css.Container)
        {
        }
    }
}
