using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    public interface IPanelFooterCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class PanelFooterWrapper<THelper> : PanelSectionWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }


    internal interface IPanelFooter : IPanelSection
    {
    }

    public class PanelFooter<THelper> : PanelSection<THelper, PanelFooter<THelper>, PanelFooterWrapper<THelper>>, IPanelFooter
        where THelper : BootstrapHelper<THelper>
    {
        internal PanelFooter(IComponentCreator<THelper> creator)
            : base(creator, Css.PanelFooter)
        {
        }
    }
}
