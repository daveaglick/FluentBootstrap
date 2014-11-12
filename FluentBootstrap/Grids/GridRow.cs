using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Grids
{
    public interface IGridRowCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class GridRowWrapper<THelper> : TagWrapper<THelper>, IGridColumnCreator<THelper>
    {
    }

    internal interface IGridRow : ITag
    {
    }

    public class GridRow<THelper> : Tag<THelper, GridRow<THelper>, GridRowWrapper<THelper>>, IGridRow
    {
        internal GridRow(IComponentCreator<THelper> creator)
            : base(creator, "div", Css.Row)
        {
        }
    }
}
