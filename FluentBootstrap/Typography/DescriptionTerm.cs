using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface IDescriptionTermCreator<TModel> : ITagCreator<TModel>
    {
    }

    public class DescriptionTermWrapper<TModel> : TagWrapper<TModel>
    {
    }
    internal interface IDescriptionTerm : ITag
    {
    }

    public class DescriptionTerm<TModel> : Tag<TModel, DescriptionTerm<TModel>, DescriptionTermWrapper<TModel>>, IDescriptionTerm
    {
        internal DescriptionTerm(IComponentCreator<TModel> creator)
            : base(creator, "dt")
        {
        }
    }
}
