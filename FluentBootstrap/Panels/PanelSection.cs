using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    public interface IPanelSection : ITag
    {
    }

    public interface IPanelSectionCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public abstract class PanelSection<TModel, TThis> : Tag<TModel, TThis>, IPanelSection
        where TThis : PanelSection<TModel, TThis>
    {
        protected PanelSection(BootstrapHelper<TModel> helper, params string[] cssClasses)
            : base(helper, "div", cssClasses)
        {
        }

        protected override void PreStart(TextWriter writer)
        {
            base.PreStart(writer);
            Pop<IPanelSection>(writer);
        }
    }
}
