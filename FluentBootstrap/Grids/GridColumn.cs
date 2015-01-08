//using FluentBootstrap.Thumbnails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Grids
{
    public class GridColumn : Tag, IHasGridColumnExtensions
        // IThumbnailCreator<THelper>,
        // IThumbnailContainerCreator<THelper>
    {
        public GridColumn(IComponentCreator creator)
            : base(creator, "div")
        {
        }
    }
}
