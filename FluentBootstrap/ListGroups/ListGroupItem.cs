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
    public class ListGroupItem : Tag, IHasLinkExtensions, IHasTextContent,
        ICanCreate<Badge>,
        ICanCreate<Heading>,
        ICanCreate<Paragraph>
    {
        public bool Active { get; set; }
        public bool Disabled { get; set; }
        public string Heading { get; set; }

        internal ListGroupItem(BootstrapHelper helper)
            : base(helper, "a", Css.ListGroupItem)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Change to a div if no link was provided
            string href = GetAttribute("href");
            if (string.IsNullOrWhiteSpace(href))
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
                GetHelper().Heading4(Heading).Component.StartAndFinish(writer);

                // Put text in a paragraph, but only if there's also a heading
                if(!string.IsNullOrWhiteSpace(textContent))
                {
                    GetHelper().Paragraph(textContent).Component.StartAndFinish(writer);
                }
            }

        }
    }
}
