using FluentBootstrap.Thumbnails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Grids
{
    public class GridColumn : Tag, IHasGridColumnExtensions,
        ICanCreate<Thumbnail>,
        ICanCreate<ThumbnailContainer>
    {
        internal GridColumn(BootstrapHelper helper)
            : base(helper, "div")
        {
        }
    }
}
