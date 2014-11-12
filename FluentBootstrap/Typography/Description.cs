using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface IDescriptionCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class DescriptionWrapper<THelper> : TagWrapper<THelper>
    {
    }
    
    internal interface IDescription : ITag
    {
    }

    public class Description<THelper> : Tag<THelper, Description<THelper>, DescriptionWrapper<THelper>>, IDescription
    {
        internal Description(IComponentCreator<THelper> creator)
            : base(creator, "dd")
        {
        }
    }
}
