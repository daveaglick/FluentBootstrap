using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    public interface IPanelTitleCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class PanelTitleWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IPanelTitle : ITag
    {
    }

    public class PanelTitle<THelper> : Tag<THelper, PanelTitle<THelper>, PanelTitleWrapper<THelper>>, IPanelTitle, IHasTextContent
        where THelper : BootstrapHelper<THelper>
    {
        internal PanelTitle(IComponentCreator<THelper> creator, string text, int headingLevel)
            : base(creator, "h" + headingLevel, Css.PanelTitle)
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
                new PanelHeading<THelper>(Helper).Start(writer);
            }

            base.OnStart(writer);
        }
    }
}
