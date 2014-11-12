using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface IDescriptionListCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class DescriptionListWrapper<THelper> : TagWrapper<THelper>, 
        IDescriptionCreator<THelper>, 
        IDescriptionTermCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IDescriptionList : ITag
    {
    }

    public class DescriptionList<THelper> : Tag<THelper, DescriptionList<THelper>, DescriptionListWrapper<THelper>>, IDescriptionList
        where THelper : BootstrapHelper<THelper>
    {
        internal DescriptionList(IComponentCreator<THelper> creator)
            : base(creator, "dl")
        {
        }
    }
}
