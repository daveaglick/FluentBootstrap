using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface IHidden : ITag
    {
    }

    public class Hidden<TModel> : Tag<TModel, Hidden<TModel>>, IHidden, IHasValueAttribute
    {
        internal Hidden(BootstrapHelper<TModel> helper)
            : base(helper, "input")
        {
            MergeAttribute("type", "hidden");
        }
    }
}
