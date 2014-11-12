using FluentBootstrap.ListGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    public interface IPanelCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class PanelWrapper<THelper> : TagWrapper<THelper>, 
        IPanelSectionCreator<THelper>, 
        IPanelTitleCreator<THelper>,
        IListGroupCreator<THelper>
    {
    }

    internal interface IPanel : ITag
    {
    }

    public class Panel<THelper> : Tag<THelper, Panel<THelper>, PanelWrapper<THelper>>, IPanel        
    {
        internal Panel(IComponentCreator<THelper> creator)
            : base(creator, "div", Css.Panel, Css.PanelDefault)
        {
        }
    }
}
