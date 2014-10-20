using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    public interface IPanelCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class PanelWrapper<TModel> : TagWrapper<TModel>, IPanelSectionCreator<TModel>, IPanelTitleCreator<TModel>
    {
    }

    internal interface IPanel : ITag
    {
    }

    public class Panel<TModel> : Tag<TModel, Panel<TModel>, PanelWrapper<TModel>>, IPanel        
    {
        internal Panel(IComponentCreator<TModel> creator)
            : base(creator, "div", Css.Panel, Css.PanelDefault)
        {
        }
    }
}
