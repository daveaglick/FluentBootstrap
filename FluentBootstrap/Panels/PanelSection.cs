using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    public interface IPanelSectionCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class PanelSectionWrapper<THelper> : TagWrapper<THelper>
    {
    }

    internal interface IPanelSection : ITag
    {
    }

    public abstract class PanelSection<THelper, TThis, TWrapper> : Tag<THelper, TThis, TWrapper>, IPanelSection
        where TThis : PanelSection<THelper, TThis, TWrapper>
        where TWrapper : PanelSectionWrapper<THelper>, new()
    {
        protected PanelSection(IComponentCreator<THelper> creator, params string[] cssClasses)
            : base(creator, "div", cssClasses)
        {
        }
        
        protected override void OnStart(TextWriter writer)
        {
            Pop<IPanelSection>(writer);

            base.OnStart(writer);
        }
    }
}
