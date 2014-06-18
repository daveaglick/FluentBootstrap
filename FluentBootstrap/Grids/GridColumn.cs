using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Grids
{
    public class GridColumn<TModel> : Tag<TModel>, IGridColumn
    {
        internal GridColumn(BootstrapHelper<TModel> helper)
            : base(helper, "div")
        {
        }

        public interface ICreate : ICreateComponent<TModel>
        {
        }
    }
}
