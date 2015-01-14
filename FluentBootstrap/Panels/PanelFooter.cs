using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    public interface IPanelFooterCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class PanelFooterWrapper<TConfig> : PanelSectionWrapper<TConfig>
        where TConfig : BootstrapConfig
    {
    }


    internal interface IPanelFooter : IPanelSection
    {
    }

    public class PanelFooter<TConfig> : PanelSection<TConfig, PanelFooter<TConfig>, PanelFooterWrapper<TConfig>>, IPanelFooter
        where TConfig : BootstrapConfig
    {
        internal PanelFooter(BootstrapHelper helper)
            : base(helper, Css.PanelFooter)
        {
        }
    }
}
