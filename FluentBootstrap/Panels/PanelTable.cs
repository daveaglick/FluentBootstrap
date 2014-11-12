using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    public interface IPanelTableCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class PanelTableWrapper<THelper> : PanelSectionWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IPanelTable : IPanelSection
    {
    }

    public class PanelTable<THelper> : PanelSection<THelper, PanelTable<THelper>, PanelTableWrapper<THelper>>, IPanelTable
        where THelper : BootstrapHelper<THelper>
    {
        internal PanelTable(IComponentCreator<THelper> creator)
            : base(creator, Css.Table)
        {
        }
    }
}
