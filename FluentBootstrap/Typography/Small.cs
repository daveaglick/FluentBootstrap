using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface ISmallCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class SmallWrapper<THelper> : TagWrapper<THelper>
    {
    }

    internal interface ISmall : ITag
    {
    }

    public class Small<THelper> : Tag<THelper, Small<THelper>, SmallWrapper<THelper>>, ISmall, IHasTextContent
    {
        internal Small(IComponentCreator<THelper> creator)
            : base(creator, "small")
        {
        }
    }
}
