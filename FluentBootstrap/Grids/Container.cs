using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentBootstrap;

namespace FluentBootstrap.Grids
{
    public class Container<TModel> : Tag<TModel>,
        GridRow<TModel>.ICreate
    {
        internal Container(BootstrapHelper<TModel> helper)
            : base(helper, "div", "container")
        {
        }

        public interface ICreate : ICreateComponent<TModel>
        {
        }
    }
}
