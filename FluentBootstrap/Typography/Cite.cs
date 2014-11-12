using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface ICiteCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class CiteWrapper<THelper> : TagWrapper<THelper>
    {
    }

    internal interface ICite : ITag
    {
    }

    public class Cite<THelper> : Tag<THelper, Cite<THelper>, CiteWrapper<THelper>>, ICite, IHasTextContent, IHasTitleAttribute
    {
        internal Cite(IComponentCreator<THelper> creator)
            : base(creator, "cite")
        {
        }
    }
}
