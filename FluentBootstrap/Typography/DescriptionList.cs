using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface IDescriptionListCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class DescriptionListWrapper<TModel> : TagWrapper<TModel>, IDescriptionCreator<TModel>, IDescriptionTermCreator<TModel>
    {
    }

    internal interface IDescriptionList : ITag
    {
    }

    public class DescriptionList<TModel> : Tag<TModel, DescriptionList<TModel>, DescriptionListWrapper<TModel>>, IDescriptionList
    {
        internal DescriptionList(IComponentCreator<TModel> creator)
            : base(creator, "dl")
        {
        }
    }
}
