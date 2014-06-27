using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    internal interface IPanel : ITag
    {
    }

    public interface IPanelCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class Panel<TModel> : Tag<TModel, Panel<TModel>>, IPanel,
        IPanelSectionCreator<TModel>,
        IPanelTitleCreator<TModel>
    {

        internal Panel(BootstrapHelper<TModel> helper)
            : base(helper, "div", "panel", "panel-default")
        {
        }
    }
}
