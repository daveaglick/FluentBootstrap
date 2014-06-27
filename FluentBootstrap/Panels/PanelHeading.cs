using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    internal interface IPanelHeading : IPanelSection
    {
    }

    public class PanelHeading<TModel> : PanelSection<TModel, PanelHeading<TModel>>, IPanelHeading,
        IPanelTitleCreator<TModel>
    {
        internal PanelHeading(BootstrapHelper<TModel> helper)
            : base(helper, "panel-heading")
        {
        }
    }
}
