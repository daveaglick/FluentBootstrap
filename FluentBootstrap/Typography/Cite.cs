using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    internal interface ICite : ITag
    {
    }

    public class Cite<TModel> : Tag<TModel, Cite<TModel>>, ICite, IHasTextAttribute, IHasTitleAttribute
    {
        internal Cite(BootstrapHelper<TModel> helper, params string[] cssClasses)
            : base(helper, "cite", cssClasses)
        {
        }
    }
}
