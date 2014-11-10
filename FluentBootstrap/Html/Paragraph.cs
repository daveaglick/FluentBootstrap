using FluentBootstrap.ListGroups;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Html
{
    public interface IParagraphCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class ParagraphWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface IParagraph : ITag
    {
    }

    public class Paragraph<TModel> : Tag<TModel, Paragraph<TModel>, ParagraphWrapper<TModel>>, IParagraph, IHasTextContent
    {
        internal Paragraph(IComponentCreator<TModel> creator)
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
