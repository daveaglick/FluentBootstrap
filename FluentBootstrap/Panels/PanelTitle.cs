using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Panels
{
    public interface IPanelTitleCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class PanelTitleWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface IPanelTitle : ITag
    {
    }

    public class PanelTitle<TModel> : Tag<TModel, PanelTitle<TModel>, PanelTitleWrapper<TModel>>, IPanelTitle, IHasTextAttribute
    {
        internal PanelTitle(IComponentCreator<TModel> creator, string text, int headingLevel)
            : base(creator, "h" + headingLevel, Css.PanelTitle)
        {
            if (headingLevel < 1 || headingLevel > 6)
            {
                throw new ArgumentOutOfRangeException("headingLevel");
            }
            TextContent = text;
        }

        protected override void PreStart(TextWriter writer)
        {
            base.PreStart(writer);

            // Make sure we're in a PanelHeading
            if (GetComponent<IPanelHeading>() == null)
            {
                new PanelHeading<TModel>(Helper).Start(writer, true);
            }
        }
    }
}
