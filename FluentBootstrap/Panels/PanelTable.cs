using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    public interface IPanelTableCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class PanelTableWrapper<TConfig> : PanelSectionWrapper<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface IPanelTable : IPanelSection
    {
    }

    public class PanelTable<TConfig> : PanelSection<TConfig, PanelTable<TConfig>, PanelTableWrapper<TConfig>>, IPanelTable
        where TConfig : BootstrapConfig
    {
        internal PanelTable(BootstrapHelper helper)
            : base(helper, Css.Table)
        {
        }
    }
}
