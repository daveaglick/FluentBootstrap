using FluentBootstrap.Thumbnails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Grids
{
    public interface IGridColumnCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class GridColumnWrapper<THelper> : TagWrapper<THelper>,
        IThumbnailCreator<THelper>, 
        IThumbnailContainerCreator<THelper>
    {
    }

    internal interface IGridColumn : ITag
    {
    }

    public class GridColumn<THelper> : Tag<THelper, GridColumn<THelper>, GridColumnWrapper<THelper>>, IGridColumn, IHasGridColumnExtensions
    {
        internal GridColumn(IComponentCreator<THelper> creator)
            : base(creator, "div")
        {
        }
    }
}
