using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface ICiteCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class CiteWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface ICite : ITag
    {
    }

    public class Cite<THelper> : Tag<THelper, Cite<THelper>, CiteWrapper<THelper>>, ICite, IHasTextContent, IHasTitleAttribute
        where THelper : BootstrapHelper<THelper>
    {
        internal Cite(IComponentCreator<THelper> creator)
            : base(creator, "cite")
        {
        }
    }
}
