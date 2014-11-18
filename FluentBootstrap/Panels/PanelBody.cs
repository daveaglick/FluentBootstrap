using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    public interface IPanelBodyCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class PanelBodyWrapper<THelper> : PanelSectionWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IPanelBody : IPanelSection
    {
    }

    public class PanelBody<THelper> : PanelSection<THelper, PanelBody<THelper>, PanelBodyWrapper<THelper>>, IPanelBody
        where THelper : BootstrapHelper<THelper>
    {
        internal PanelBody(IComponentCreator<THelper> creator)
            : base(creator, Css.PanelBody)
        {
        }
    }
}
