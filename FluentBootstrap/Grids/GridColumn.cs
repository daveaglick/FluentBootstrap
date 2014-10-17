using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Grids
{
    public interface IGridColumnCreator<TModel> : ITagCreator<TModel>
    {
    }

    public class GridColumnWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface IGridColumn : ITag
    {
    }

    public class GridColumn<TModel> : Tag<TModel, GridColumn<TModel>, GridColumnWrapper<TModel>>, IGridColumn, IHasGridColumnExtensions
    {
        internal GridColumn(IComponentCreator<TModel> creator)
            : base(creator, "div")
        {
        }
    }
}
