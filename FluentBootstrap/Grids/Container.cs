using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentBootstrap;

namespace FluentBootstrap.Grids
{
    internal interface IContainer : ITag
    {
    }

    public interface IContainerCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class Container<TModel> : Tag<TModel, Container<TModel>>, IContainer,
        IGridRowCreator<TModel>
    {
        internal Container(BootstrapHelper<TModel> helper)
            : base(helper, "div", "container")
        {
        }
    }
}
