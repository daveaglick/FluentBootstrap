using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    public interface IPanelBodyCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class PanelBodyWrapper<TConfig> : PanelSectionWrapper<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface IPanelBody : IPanelSection
    {
    }

    public class PanelBody<TConfig> : PanelSection<TConfig, PanelBody<TConfig>, PanelBodyWrapper<TConfig>>, IPanelBody
        where TConfig : BootstrapConfig
    {
        internal PanelBody(BootstrapHelper helper)
            : base(helper, Css.PanelBody)
        {
        }
    }
}
