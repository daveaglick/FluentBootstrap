using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    internal interface IDescriptionDescription : ITag
    {
    }

    public class DescriptionDescription<TModel> : Tag<TModel, DescriptionDescription<TModel>>, IDescriptionDescription
    {
        internal DescriptionDescription(BootstrapHelper<TModel> helper)
            : base(helper, "dd")
        {
        }
    }
}
