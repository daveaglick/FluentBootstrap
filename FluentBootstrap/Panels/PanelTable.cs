using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    public interface IPanelTable : IPanelSection
    {
    }

    public class PanelTable<TModel> : PanelSection<TModel, PanelTable<TModel>>, IPanelTable
    {
        internal PanelTable(BootstrapHelper<TModel> helper)
            : base(helper, "table")
        {
        }
    }
}
