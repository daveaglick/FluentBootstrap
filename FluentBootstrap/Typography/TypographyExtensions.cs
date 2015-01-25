using FluentBootstrap.Typography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FluentBootstrap.Html;

namespace FluentBootstrap
{
    public static class TypographyExtensions
    {
        // Headings

        public static ComponentBuilder<TConfig, Heading> Heading<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, int size, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Heading>
        {
            if(size < 1)
            {
                size = 1;
            }
            else if(size > 6)
            {
                size = 6;
            }
            return new ComponentBuilder<TConfig, Heading>(helper.Config, new Heading(helper, "h" + size))
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, Heading> Heading1<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Heading>
        {
            return new ComponentBuilder<TConfig, Heading>(helper.Config, new Heading(helper, "h1"))
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, Heading> Heading2<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Heading>
        {
            return new ComponentBuilder<TConfig, Heading>(helper.Config, new Heading(helper, "h2"))
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, Heading> Heading3<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Heading>
        {
            return new ComponentBuilder<TConfig, Heading>(helper.Config, new Heading(helper, "h3"))
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, Heading> Heading4<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Heading>
        {
            return new ComponentBuilder<TConfig, Heading>(helper.Config, new Heading(helper, "h4"))
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, Heading> Heading5<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Heading>
        {
            return new ComponentBuilder<TConfig, Heading>(helper.Config, new Heading(helper, "h5"))
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, Heading> Heading6<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Heading>
        {
            return new ComponentBuilder<TConfig, Heading>(helper.Config, new Heading(helper, "h6"))
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, THeading> SetSmallText<TConfig, THeading>(this ComponentBuilder<TConfig, THeading> builder, string text)
            where TConfig : BootstrapConfig
            where THeading : Heading
        {
            builder.Component.SmallText = text;
            return builder;
        }

        // Body copy

        public static ComponentBuilder<TConfig, Small> Small<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Small>

        {
            return new ComponentBuilder<TConfig, Small>(helper.Config, new Small(helper))
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, TTag> MakeSmall<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, bool toggle = true)
            where TConfig : BootstrapConfig
            where TTag : Tag
        {
            builder.Component.ToggleCss(Css.Small, toggle);
            return builder;
        }

        public static ComponentBuilder<TConfig, Element> Lead<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<TConfig, Element>(helper.Config, new Element(helper, "p"))
                .AddCss(Css.Lead)
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, Element> Marked<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<TConfig, Element>(helper.Config, new Element(helper, "mark"))
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, Element> Deleted<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<TConfig, Element>(helper.Config, new Element(helper, "del"))
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, Element> Strikethrough<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<TConfig, Element>(helper.Config, new Element(helper, "s"))
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, Element> Inserted<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<TConfig, Element>(helper.Config, new Element(helper, "ins"))
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, Element> Underlined<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<TConfig, Element>(helper.Config, new Element(helper, "u"))
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, Element> Strong<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<TConfig, Element>(helper.Config, new Element(helper, "strong"))
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, Element> Bold<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<TConfig, Element>(helper.Config, new Element(helper, "b"))
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, Element> Emphasis<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<TConfig, Element>(helper.Config, new Element(helper, "em"))
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, Element> Italics<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<TConfig, Element>(helper.Config, new Element(helper, "i"))
                .SetText(text);
        }

        // Text alignment and transformation

        public static ComponentBuilder<TConfig, TTag> SetAlignment<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, TextAlignment alignment)
            where TConfig : BootstrapConfig
            where TTag : Tag
        {
            builder.Component.ToggleCss(alignment);
            return builder;
        }

        public static ComponentBuilder<TConfig, TTag> SetTransformation<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, TextTransformation transformation)
            where TConfig : BootstrapConfig
            where TTag : Tag
        {
            builder.Component.ToggleCss(transformation);
            return builder;
        }

        // Abbreviation

        public static ComponentBuilder<TConfig, Abbr> Abbreviation<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string title, string text)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Abbr>
        {
            return new ComponentBuilder<TConfig, Abbr>(helper.Config, new Abbr(helper))
                .SetTitle(title)
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, Abbr> SetInitialism<TConfig>(this ComponentBuilder<TConfig, Abbr> builder, bool initialism = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.ToggleCss(Css.Initialism, initialism);
            return builder;
        }

        // Address

        public static ComponentBuilder<TConfig, Element> Address<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<TConfig, Element>(helper.Config, new Element(helper, "address"))
                .SetText(text);
        }

        // Blockquote

        public static ComponentBuilder<TConfig, Blockquote> Blockquote<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string quote = null, string footer = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Blockquote>
        {
            return new ComponentBuilder<TConfig, Blockquote>(helper.Config, new Blockquote(helper))
                .SetQuote(quote)
                .SetFooter(footer);
        }

        public static ComponentBuilder<TConfig, Blockquote> SetQuote<TConfig>(this ComponentBuilder<TConfig, Blockquote> builder, string quote)
            where TConfig : BootstrapConfig
        {
            builder.Component.Quote = quote;
            return builder;
        }

        public static ComponentBuilder<TConfig, Blockquote> SetFooter<TConfig>(this ComponentBuilder<TConfig, Blockquote> builder, string footer)
            where TConfig : BootstrapConfig
        {
            builder.Component.Footer = footer;
            return builder;
        }

        public static ComponentBuilder<TConfig, Blockquote> SetReverse<TConfig>(this ComponentBuilder<TConfig, Blockquote> builder, bool reverse = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.ToggleCss(Css.BlockquoteReverse, reverse);
            return builder;
        }

        public static ComponentBuilder<TConfig, Element> Footer<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<TConfig, Element>(helper.Config, new Element(helper, "footer"))
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, Cite> Cite<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string title = null, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Cite>
        {
            return new ComponentBuilder<TConfig, Cite>(helper.Config, new Cite(helper))
                .SetTitle(title)
                .SetText(text);
        }

        // List

        public static ComponentBuilder<TConfig, Typography.List> List<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, ListType listType = ListType.Unstyled)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Typography.List>
        {
            return new ComponentBuilder<TConfig, Typography.List>(helper.Config, new Typography.List(helper, listType));
        }

        public static ComponentBuilder<TConfig, ListItem> ListItem<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, object content = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<ListItem>
        {
            return new ComponentBuilder<TConfig, ListItem>(helper.Config, new ListItem(helper))
                .AddContent(content);
        }

        // DescriptionList

        public static ComponentBuilder<TConfig, DescriptionList> DescriptionList<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<DescriptionList>
        {
            return new ComponentBuilder<TConfig, DescriptionList>(helper.Config, new DescriptionList(helper));
        }

        public static ComponentBuilder<TConfig, DescriptionList> SetHorizontal<TConfig>(this ComponentBuilder<TConfig, DescriptionList> builder, bool horizontal = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.ToggleCss(Css.DlHorizontal, horizontal);
            return builder;
        }

        public static ComponentBuilder<TConfig, DescriptionTerm> DescriptionTerm<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, object content = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<DescriptionTerm>
        {
            return new ComponentBuilder<TConfig, DescriptionTerm>(helper.Config, new DescriptionTerm(helper))
                .AddContent(content);
        }

        public static ComponentBuilder<TConfig, Description> Description<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, object content = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Description>
        {
            return new ComponentBuilder<TConfig, Description>(helper.Config, new Description(helper))
                .AddContent(content);
        }

        // Code, etc.

        public static ComponentBuilder<TConfig, Element> Code<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<TConfig, Element>(helper.Config, new Element(helper, "code"))
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, Element> Keyboard<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<TConfig, Element>(helper.Config, new Element(helper, "kbd"))
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, Pre> Preformatted<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Pre>
        {
            return new ComponentBuilder<TConfig, Pre>(helper.Config, new Pre(helper))
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, Pre> SetScrollable<TConfig>(this ComponentBuilder<TConfig, Pre> builder, bool scrollable = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.ToggleCss(Css.PreScrollable, scrollable);
            return builder;
        }

        public static ComponentBuilder<TConfig, Element> Variable<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<TConfig, Element>(helper.Config, new Element(helper, "var"))
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, Element> Sample<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Tag>
        {
            return new ComponentBuilder<TConfig, Element>(helper.Config, new Element(helper, "samp"))
                .SetText(text);
        }
    }
}
