using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    public interface IPanelHeadingCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class PanelHeadingWrapper<TModel> : PanelSectionWrapper<TModel>, IPanelTitleCreator<TModel>
    {
    }
    internal interface IPanelHeading : IPanelSection
    {
    }

    public class PanelHeading<TModel> : PanelSection<TModel, PanelHeading<TModel>, PanelHeadingWrapper<TModel>>, IPanelHeading
        
    {
        internal PanelHeading(IComponentCreator<TModel> creator)
            : base(creator, Css.PanelHeading)
        {
        }
    }
}
