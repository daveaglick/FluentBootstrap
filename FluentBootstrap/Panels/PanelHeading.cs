using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    public interface IPanelHeadingCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class PanelHeadingWrapper<THelper> : PanelSectionWrapper<THelper>, IPanelTitleCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IPanelHeading : IPanelSection
    {
    }

    public class PanelHeading<THelper> : PanelSection<THelper, PanelHeading<THelper>, PanelHeadingWrapper<THelper>>, IPanelHeading
        where THelper : BootstrapHelper<THelper>
        
    {
        internal PanelHeading(IComponentCreator<THelper> creator)
            : base(creator, Css.PanelHeading)
        {
        }
    }
}
