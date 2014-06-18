using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Grids
{
    public class GridRow<TModel> : Tag<TModel>,
        GridColumn<TModel>.ICreate
    {
        internal GridRow(BootstrapHelper<TModel> helper)
            : base(helper, "div", "row")
        {
        }

        public interface ICreate : ICreateComponent<TModel>
        {
        }
    }
}
