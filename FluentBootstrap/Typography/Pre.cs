using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface IPreCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class PreWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IPre : ITag
    {
    }

    public class Pre<THelper> : Tag<THelper, Pre<THelper>, PreWrapper<THelper>>, IPre, IHasTextContent
        where THelper : BootstrapHelper<THelper>
    {
        internal Pre(IComponentCreator<THelper> creator)
            : base(creator, "pre")
        {
        }
    }
}
