using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface ISmallCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class SmallWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface ISmall : ITag
    {
    }

    public class Small<THelper> : Tag<THelper, Small<THelper>, SmallWrapper<THelper>>, ISmall, IHasTextContent
        where THelper : BootstrapHelper<THelper>
    {
        internal Small(IComponentCreator<THelper> creator)
            : base(creator, "small")
        {
        }
    }
}
