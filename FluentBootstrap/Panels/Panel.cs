using FluentBootstrap.ListGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    public interface IPanelCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class PanelWrapper<TConfig> : TagWrapper<TConfig>, 
        IPanelSectionCreator<TConfig>, 
        IPanelTitleCreator<TConfig>,
        IListGroupCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface IPanel : ITag
    {
    }

    public class Panel<TConfig> : Tag<TConfig, Panel<TConfig>, PanelWrapper<TConfig>>, IPanel
        where TConfig : BootstrapConfig
    {
        internal Panel(IComponentCreator<TConfig> creator)
            : base(helper, "div", Css.Panel, Css.PanelDefault)
        {
        }
    }
}
