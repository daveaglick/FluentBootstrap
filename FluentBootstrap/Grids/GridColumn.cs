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

    public class GridColumnParent<TModel> : TagParent<TModel>
    {
    }

    internal interface IGridColumn : ITag
    {
    }

    public class GridColumn<TModel> : Tag<TModel, GridColumn<TModel>, GridColumnParent<TModel>>, IGridColumn, IHasGridColumnExtensions
    {
        internal GridColumn(IComponentCreator<TModel> creator)
            : base(creator, "div")
        {
        }
    }
}
