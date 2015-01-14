using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    public interface IPanelTitleCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class PanelTitleWrapper<TConfig> : TagWrapper<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface IPanelTitle : ITag
    {
    }

    public class PanelTitle<TConfig> : Tag<TConfig, PanelTitle<TConfig>, PanelTitleWrapper<TConfig>>, IPanelTitle, IHasTextContent
        where TConfig : BootstrapConfig
    {
        internal PanelTitle(BootstrapHelper helper, string text, int headingLevel)
            : base(helper, "h" + headingLevel, Css.PanelTitle)
        {
            if (headingLevel < 1 || headingLevel > 6)
            {
                throw new ArgumentOutOfRangeException("headingLevel");
            }
            TextContent = text;
        }

        protected override void OnStart(TextWriter writer)
        {
            // Make sure we're in a PanelHeading
            if (GetComponent<IPanelHeading>() == null)
            {
                new PanelHeading<TConfig>(Helper).Start(writer);
            }

            base.OnStart(writer);
        }
    }
}
