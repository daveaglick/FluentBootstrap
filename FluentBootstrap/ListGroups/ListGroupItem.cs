using FluentBootstrap.Badges;
using FluentBootstrap.Html;
using FluentBootstrap.Links;
using FluentBootstrap.Typography;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.ListGroups
{
    public interface IListGroupItemCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class ListGroupItemWrapper<TModel> : TagWrapper<TModel>,
        IBadgeCreator<TModel>,
        IHeadingCreator<TModel>,
        IParagraphCreator<TModel>
    {
    }

    internal interface IListGroupItem : ITag
    {
    }

    public class ListGroupItem<TModel> : Tag<TModel, ListGroupItem<TModel>, ListGroupItemWrapper<TModel>>, IListGroupItem, IHasLinkExtensions, IHasTextContent
    {
        internal bool Active { get; set; }
        internal bool Disabled { get; set; }
        internal string Heading { get; set; }

        internal ListGroupItem(IComponentCreator<TModel> creator)
            : base(creator, "a", Css.ListGroupItem)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Change to a div if no link was provided
            string href;
            if (!TagBuilder.Attributes.TryGetValue("href", out href) || string.IsNullOrWhiteSpace(href))
            {
                TagName = "div";
            }

            if(Active)
            {
                this.AddCss(Css.Active);
            }
            if(Disabled)
            {
                this.AddCss(Css.Disabled);
            }

            // Cache the text content for after opening tag
            string textContent = null;
            if (!string.IsNullOrWhiteSpace(Heading))
            {
                textContent = TextContent;
                TextContent = null;
            }

            base.OnStart(writer);

            // Add the heading
            if(!string.IsNullOrWhiteSpace(Heading))
            {
                Helper.Heading4(Heading).StartAndFinish(writer);

                // Put text in a paragraph, but only if there's also a heading
                if(!string.IsNullOrWhiteSpace(textContent))
                {
                    Helper.Paragraph(textContent).StartAndFinish(writer);
                }
            }

        }
    }
}
