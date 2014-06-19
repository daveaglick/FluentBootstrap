using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Grids
{
    public interface IGridRow : ITag
    {
    }

    public interface IGridRowCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class GridRow<TModel> : Tag<TModel, GridRow<TModel>>, IGridRow,
        IGridColumnCreator<TModel>
    {
        internal GridRow(BootstrapHelper<TModel> helper)
            : base(helper, "div", "row")
        {
        }
    }
}
