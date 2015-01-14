using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    public interface IPanelHeadingCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class PanelHeadingWrapper<TConfig> : PanelSectionWrapper<TConfig>, IPanelTitleCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface IPanelHeading : IPanelSection
    {
    }

    public class PanelHeading<TConfig> : PanelSection<TConfig, PanelHeading<TConfig>, PanelHeadingWrapper<TConfig>>, IPanelHeading
        where TConfig : BootstrapConfig
        
    {
        internal PanelHeading(BootstrapHelper helper)
            : base(helper, Css.PanelHeading)
        {
        }
    }
}
