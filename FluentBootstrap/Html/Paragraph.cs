using FluentBootstrap.ListGroups;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Html
{
    public interface IParagraphCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class ParagraphWrapper<THelper> : TagWrapper<THelper>
    {
    }

    internal interface IParagraph : ITag
    {
    }

    public class Paragraph<THelper> : Tag<THelper, Paragraph<THelper>, ParagraphWrapper<THelper>>, IParagraph, IHasTextContent
    {
        internal Paragraph(IComponentCreator<THelper> creator)
            : base(creator, "p")
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Add the appropriate CSS class if in a list group item
            if (GetComponent<IListGroupItem>() != null)
            {
                this.AddCss(Css.ListGroupItemText);
            }

            base.OnStart(writer);
        }
    }
}
