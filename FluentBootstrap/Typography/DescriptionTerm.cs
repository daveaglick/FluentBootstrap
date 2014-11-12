using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface IDescriptionTermCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class DescriptionTermWrapper<THelper> : TagWrapper<THelper>
    {
    }

    internal interface IDescriptionTerm : ITag
    {
    }

    public class DescriptionTerm<THelper> : Tag<THelper, DescriptionTerm<THelper>, DescriptionTermWrapper<THelper>>, IDescriptionTerm
    {
        internal DescriptionTerm(IComponentCreator<THelper> creator)
            : base(creator, "dt")
        {
        }
    }
}
