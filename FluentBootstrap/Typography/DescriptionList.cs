using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    internal interface IDescriptionList : ITag
    {
    }

    public interface IDescriptionListCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public interface IDescriptionListItemCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class DescriptionList<TModel> : Tag<TModel, DescriptionList<TModel>>, IDescriptionList,
        IDescriptionListItemCreator<TModel>
    {

        internal DescriptionList(BootstrapHelper<TModel> helper)
            : base(helper, "dl")
        {
        }
    }
}
