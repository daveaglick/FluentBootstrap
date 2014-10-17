using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Grids
{
    public interface IGridRowCreator<TModel> : ITagCreator<TModel>
    {
    }

    public class GridRowWrapper<TModel> : TagWrapper<TModel>, IGridColumnCreator<TModel>
    {
    }

    internal interface IGridRow : ITag
    {
    }

    public class GridRow<TModel> : Tag<TModel, GridRow<TModel>, GridRowWrapper<TModel>>, IGridRow
    {
        internal GridRow(IComponentCreator<TModel> creator)
            : base(creator, "div", Css.Row)
        {
        }
    }
}
