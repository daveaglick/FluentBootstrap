using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    public interface IPanelSectionCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class PanelSectionWrapper<TConfig> : TagWrapper<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface IPanelSection : ITag
    {
    }

    public abstract class PanelSection<TConfig, TThis, TWrapper> : Tag<TConfig, TThis, TWrapper>, IPanelSection
        where TConfig : BootstrapConfig
        where TThis : PanelSection<TConfig, TThis, TWrapper>
        where TWrapper : PanelSectionWrapper<TConfig>, new()
    {
        protected PanelSection(BootstrapHelper helper, params string[] cssClasses)
            : base(helper, "div", cssClasses)
        {
        }
        
        protected override void OnStart(TextWriter writer)
        {
            Pop<IPanelSection>(writer);

            base.OnStart(writer);
        }
    }
}
