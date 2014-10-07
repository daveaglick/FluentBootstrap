using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    internal interface IDescriptionTerm : ITag
    {
    }

    public class DescriptionTerm<TModel> : Tag<TModel, DescriptionTerm<TModel>>, IDescriptionTerm
    {
        internal DescriptionTerm(BootstrapHelper<TModel> helper)
            : base(helper, "dt")
        {
        }
    }
}
