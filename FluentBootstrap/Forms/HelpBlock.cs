using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface IHelpBlockCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class HelpBlockWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface IHelpBlock : ITag
    {
    }

    public class HelpBlock<TModel> : Tag<TModel, HelpBlock<TModel>, HelpBlockWrapper<TModel>>, IHelpBlock, IHasTextAttribute
    {
        internal HelpBlock(IComponentCreator<TModel> creator)
            : base(creator, "div", Css.HelpBlock)
        {
        }
    }
}
