using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    internal interface IPanelFooter : IPanelSection
    {
    }

    public class PanelFooter<TModel> : PanelSection<TModel, PanelFooter<TModel>>, IPanelFooter
    {
        internal PanelFooter(BootstrapHelper<TModel> helper)
            : base(helper, "panel-footer")
        {
        }
    }
}
