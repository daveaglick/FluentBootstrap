using System.Web.Mvc;
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

        public static Heading<TModel> Heading1<TModel>(this ITagCreator<TModel> creator, string text, params string[] cssClasses)
        {
            return new Heading<TModel>(creator.GetHelper(), "h1", text, cssClasses);
        }

        public static Heading<TModel> Heading2<TModel>(this ITagCreator<TModel> creator, string text, params string[] cssClasses)
        {
            return new Heading<TModel>(creator.GetHelper(), "h2", text, cssClasses);
        }

        public static Heading<TModel> Heading3<TModel>(this ITagCreator<TModel> creator, string text, params string[] cssClasses)
        {
            return new Heading<TModel>(creator.GetHelper(), "h3", text, cssClasses);
        }

        public static Heading<TModel> Heading4<TModel>(this ITagCreator<TModel> creator, string text, params string[] cssClasses)
        {
            return new Heading<TModel>(creator.GetHelper(), "h4", text, cssClasses);
        }

        public static Heading<TModel> Heading5<TModel>(this ITagCreator<TModel> creator, string text, params string[] cssClasses)
        {
            return new Heading<TModel>(creator.GetHelper(), "h5", text, cssClasses);
        }

        public static Heading<TModel> Heading6<TModel>(this ITagCreator<TModel> creator, string text, params string[] cssClasses)
        {
            return new Heading<TModel>(creator.GetHelper(), "h6", text, cssClasses);
        }

        public static Heading<TModel> Small<TModel>(this Heading<TModel> heading, string text)
        {
            heading.Small = text;
            return heading;
        }

        // Body copy

        public static Element<TModel> Small<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator.GetHelper(), "small", cssClasses).Text(text);
        }

        public static TThis Small<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.Small, toggle);
        }

        public static Element<TModel> Lead<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator.GetHelper(), "p", Css.Lead).Text(text);
        }

        public static Element<TModel> Marked<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator.GetHelper(), "mark", cssClasses).Text(text);
        }

        public static Element<TModel> Deleted<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator.GetHelper(), "del", cssClasses).Text(text);
        }

        public static Element<TModel> Strikethrough<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator.GetHelper(), "s", cssClasses).Text(text);
        }

        public static Element<TModel> Inserted<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator.GetHelper(), "ins", cssClasses).Text(text);
        }

        public static Element<TModel> Underlined<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator.GetHelper(), "u", cssClasses).Text(text);
        }

        public static Element<TModel> Strong<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator.GetHelper(), "strong", cssClasses).Text(text);
        }

        public static Element<TModel> Bold<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator.GetHelper(), "b", cssClasses).Text(text);
        }

        public static Element<TModel> Emphasis<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator.GetHelper(), "em", cssClasses).Text(text);
        }

        public static Element<TModel> Italics<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator.GetHelper(), "i", cssClasses).Text(text);
        }

        // Alignment

        public static TThis TextLeft<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.TextLeft, toggle, Css.TextCenter, Css.TextRight, Css.TextJustify, Css.TextNoWrap);
        }

        public static TThis TextCenter<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.TextCenter, toggle, Css.TextLeft, Css.TextRight, Css.TextJustify, Css.TextNoWrap);
        }

        public static TThis TextRight<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.TextRight, toggle, Css.TextCenter, Css.TextLeft, Css.TextJustify, Css.TextNoWrap);
        }

        public static TThis TextJustify<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.TextJustify, toggle, Css.TextCenter, Css.TextRight, Css.TextLeft, Css.TextNoWrap);
        }

        public static TThis TextNoWrap<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.TextNoWrap, toggle, Css.TextCenter, Css.TextRight, Css.TextJustify, Css.TextLeft);
        }

        // Transformation

        public static TThis TextLowercase<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.TextLowercase, toggle, Css.TextUppercase, Css.TextCapitalize);
        }

        public static TThis TextUppercase<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.TextUppercase, toggle, Css.TextLowercase, Css.TextCapitalize);
        }

        public static TThis TextCapitalize<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.TextCapitalize, toggle, Css.TextLowercase, Css.TextUppercase);
        }

        // Abbreviation

        public static Abbr<TModel> Abbreviation<TModel>(this ITagCreator<TModel> creator, string title, string text, params string[] cssClasses)
        {
            return new Abbr<TModel>(creator.GetHelper(), cssClasses).Title(title).Text(text);
        }

        public static Abbr<TModel> Initialism<TModel>(this Abbr<TModel> abbr, bool toggle = true)
        {
            return abbr.ToggleCss(Css.Initialism, toggle);
        }

        // Address

        public static Element<TModel> Address<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator.GetHelper(), "address", cssClasses).Text(text);
        }

        // Blockquote

        public static Blockquote<TModel> Blockquote<TModel>(this ITagCreator<TModel> creator, string quote = null, string footer = null, params string[] cssClasses)
        {
            return new Blockquote<TModel>(creator.GetHelper(), cssClasses).Quote(quote).Footer(footer);
        }

        public static Blockquote<TModel> Quote<TModel>(this Blockquote<TModel> blockquote, string quote)
        {
            blockquote.Quote = quote;
            return blockquote;
        }

        public static Blockquote<TModel> Footer<TModel>(this Blockquote<TModel> blockquote, string footer)
        {
            blockquote.Footer = footer;
            return blockquote;
        }

        public static Blockquote<TModel> Reverse<TModel>(this Blockquote<TModel> blockquote, bool toggle = true)
        {
            return blockquote.ToggleCss(Css.BlockquoteReverse, toggle);
        }
        
        public static Element<TModel> Footer<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator.GetHelper(), "footer", cssClasses).Text(text);
        }

        public static Cite<TModel> Cite<TModel>(this ITagCreator<TModel> creator, string title = null, string text = null, params string[] cssClasses)
        {
            return new Cite<TModel>(creator.GetHelper(), cssClasses).Title(title).Text(text);
        }
        
        // List

        public static Typography.List<TModel> List<TModel>(this IListCreator<TModel> creator, ListType listType = ListType.Unstyled)
        {
            return new Typography.List<TModel>(creator.GetHelper(), listType);
        }

        public static Typography.List<TModel> ListFor<TModel, TValue>(this IListCreator<TModel> creator, Expression<Func<TModel, IEnumerable<TValue>>> expression, Func<TValue, object> item, ListType listType = ListType.Unstyled)
        {
            Typography.List<TModel> list = new Typography.List<TModel>(creator.GetHelper(), listType);
            IEnumerable<TValue> values = ModelMetadata.FromLambdaExpression(expression, creator.GetHelper().HtmlHelper.ViewData).Model as IEnumerable<TValue>;
            if (values != null)
            {
                foreach (TValue value in values)
                {
                    list.AddChild(x => x.ListItem(item(value)));
                }
            }
            return list;
        }

        public static ListItem<TModel> ListItem<TModel>(this IListItemCreator<TModel> creator, object content = null)
        {
            return new ListItem<TModel>(creator.GetHelper()).AddContent(content);
        }

        // DescriptionList

        public static DescriptionList<TModel> DescriptionList<TModel>(this IDescriptionListCreator<TModel> creator)
        {
            return new DescriptionList<TModel>(creator.GetHelper());
        }

        public static DescriptionList<TModel> Horizontal<TModel>(this DescriptionList<TModel> descriptionList, bool horizontal = true)
        {
            descriptionList.ToggleCss(Css.DlHorizontal, horizontal);
            return descriptionList;
        }

        public static DescriptionTerm<TModel> DescriptionTerm<TModel>(this IDescriptionListItemCreator<TModel> creator, object content = null)
        {
            return new DescriptionTerm<TModel>(creator.GetHelper()).AddContent(content);
        }

        public static DescriptionDescription<TModel> DescriptionDescription<TModel>(this IDescriptionListItemCreator<TModel> creator, object content = null)
        {
            return new DescriptionDescription<TModel>(creator.GetHelper()).AddContent(content);
        }

        // Code, etc.

        public static Element<TModel> Code<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator.GetHelper(), "code", cssClasses).Text(text);
        }

        public static Element<TModel> Keyboard<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator.GetHelper(), "kbd", cssClasses).Text(text);
        }

        public static Pre<TModel> Preformatted<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Pre<TModel>(creator.GetHelper(), cssClasses).Text(text);
        }

        public static Pre<TModel> Scrollable<TModel>(this Pre<TModel> pre, bool toggle = true)
        {
            return pre.ToggleCss(Css.PreScrollable, toggle);
        }

        public static Element<TModel> Variable<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator.GetHelper(), "var", cssClasses).Text(text);
        }

        public static Element<TModel> Sample<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator.GetHelper(), "samp", cssClasses).Text(text);
        }
    }
}
