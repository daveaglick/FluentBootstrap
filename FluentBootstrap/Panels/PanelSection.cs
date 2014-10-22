using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    public interface IPanelSectionCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class PanelSectionWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface IPanelSection : ITag
    {
    }

    public abstract class PanelSection<TModel, TThis, TWrapper> : Tag<TModel, TThis, TWrapper>, IPanelSection
        where TThis : PanelSection<TModel, TThis, TWrapper>
        where TWrapper : PanelSectionWrapper<TModel>, new()
    {
        protected PanelSection(IComponentCreator<TModel> creator, params string[] cssClasses)
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
