using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    internal interface IPanelBody : IPanelSection
    {
    }

    public class PanelBody<TModel> : PanelSection<TModel, PanelBody<TModel>>, IPanelBody
    {
        internal PanelBody(BootstrapHelper<TModel> helper)
            : base(helper, Css.PanelBody)
        {
        }
    }
}
