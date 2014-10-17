using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface IDescriptionCreator<TModel> : ITagCreator<TModel>
    {
    }

    public class DescriptionWrapper<TModel> : TagWrapper<TModel>
    {
    }
    
    internal interface IDescription : ITag
    {
    }

    public class Description<TModel> : Tag<TModel, Description<TModel>, DescriptionWrapper<TModel>>, IDescription
    {
        internal Description(IComponentCreator<TModel> creator)
            : base(creator, "dd")
        {
        }
    }
}
