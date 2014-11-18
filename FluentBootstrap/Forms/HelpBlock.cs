using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface IHelpBlockCreator<THelper> : IComponentCreator<THelper> 
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class HelpBlockWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IHelpBlock : ITag
    {
    }

    public class HelpBlock<THelper> : Tag<THelper, HelpBlock<THelper>, HelpBlockWrapper<THelper>>, IHelpBlock, IHasTextContent
        where THelper : BootstrapHelper<THelper>
    {
        internal HelpBlock(IComponentCreator<THelper> creator)
            : base(creator, "div", Css.HelpBlock)
        {
        }
    }
}
