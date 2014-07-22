using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    internal interface IPre : ITag
    {
    }

    public class Pre<TModel> : Tag<TModel, Pre<TModel>>, IPre, IHasTextAttribute
    {
        internal Pre(BootstrapHelper<TModel> helper, params string[] cssClasses)
            : base(helper, "pre", cssClasses)
        {
        }
    }
}
