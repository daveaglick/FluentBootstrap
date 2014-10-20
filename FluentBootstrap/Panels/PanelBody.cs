using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    public interface IPanelBodyCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class PanelBodyWrapper<TModel> : PanelSectionWrapper<TModel>
    {
    }

    internal interface IPanelBody : IPanelSection
    {
    }

    public class PanelBody<TModel> : PanelSection<TModel, PanelBody<TModel>, PanelBodyWrapper<TModel>>, IPanelBody
    {
        internal PanelBody(IComponentCreator<TModel> creator)
            : base(creator, Css.PanelBody)
        {
        }
    }
}
