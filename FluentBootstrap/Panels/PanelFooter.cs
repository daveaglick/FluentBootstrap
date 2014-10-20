using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    public interface IPanelFooterCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class PanelFooterWrapper<TModel> : PanelSectionWrapper<TModel>
    {
    }

    internal interface IPanelFooter : IPanelSection
    {
    }

    public class PanelFooter<TModel> : PanelSection<TModel, PanelFooter<TModel>, PanelFooterWrapper<TModel>>, IPanelFooter
    {
        internal PanelFooter(IComponentCreator<TModel> creator)
            : base(creator, Css.PanelFooter)
        {
        }
    }
}
