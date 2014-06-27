using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Grids
{
    internal interface IGridColumn : ITag
    {
    }

    public interface IGridColumnCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class GridColumn<TModel> : Tag<TModel, GridColumn<TModel>>, IGridColumn, IHasGridColumnExtensions
    {
        internal GridColumn(BootstrapHelper<TModel> helper)
            : base(helper, "div")
        {
        }
    }
}
