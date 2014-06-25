using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface IHelpBlock : ITag
    {
    }

    public interface IHelpBlockCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class HelpBlock<TModel> : Tag<TModel, HelpBlock<TModel>>, IHelpBlock, IHasTextAttribute
    {
        internal HelpBlock(BootstrapHelper<TModel> helper)
            : base(helper, "div", "help-block")
        {
        }
    }
}
