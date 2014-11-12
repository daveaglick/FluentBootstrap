using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface IHelpBlockCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class HelpBlockWrapper<THelper> : TagWrapper<THelper>
    {
    }

    internal interface IHelpBlock : ITag
    {
    }

    public class HelpBlock<THelper> : Tag<THelper, HelpBlock<THelper>, HelpBlockWrapper<THelper>>, IHelpBlock, IHasTextContent
    {
        internal HelpBlock(IComponentCreator<THelper> creator)
            : base(creator, "div", Css.HelpBlock)
        {
        }
    }
}
