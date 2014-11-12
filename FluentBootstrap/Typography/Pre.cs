using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface IPreCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class PreWrapper<THelper> : TagWrapper<THelper>
    {
    }

    internal interface IPre : ITag
    {
    }

    public class Pre<THelper> : Tag<THelper, Pre<THelper>, PreWrapper<THelper>>, IPre, IHasTextContent
    {
        internal Pre(IComponentCreator<THelper> creator)
            : base(creator, "pre")
        {
        }
    }
}
