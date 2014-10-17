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
            return new Heading<TModel>(creator, "h1", text, cssClasses);
        }

        public static Heading<TModel> Heading2<TModel>(this ITagCreator<TModel> creator, string text, params string[] cssClasses)
        {
            return new Heading<TModel>(creator, "h2", text, cssClasses);
        }

        public static Heading<TModel> Heading3<TModel>(this ITagCreator<TModel> creator, string text, params string[] cssClasses)
        {
            return new Heading<TModel>(creator, "h3", text, cssClasses);
        }

        public static Heading<TModel> Heading4<TModel>(this ITagCreator<TModel> creator, string text, params string[] cssClasses)
        {
            return new Heading<TModel>(creator, "h4", text, cssClasses);
        }

        public static Heading<TModel> Heading5<TModel>(this ITagCreator<TModel> creator, string text, params string[] cssClasses)
        {
            return new Heading<TModel>(creator, "h5", text, cssClasses);
        }

        public static Heading<TModel> Heading6<TModel>(this ITagCreator<TModel> creator, string text, params string[] cssClasses)
        {
            return new Heading<TModel>(creator, "h6", text, cssClasses);
        }

        public static Heading<TModel> SetSmallText<TModel>(this Heading<TModel> heading, string text)
        {
            heading.SmallText = text;
            return heading;
        }

        // Body copy

        public static Element<TModel> Small<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator, "small", cssClasses).SetText(text);
        }

        public static TThis SetSmall<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, bool toggle = true)
            where TThis : Tag<TModel, TThis, TWrapper>
            where TWrapper : TagWrapper<TModel>, new()
        {
            return component.GetThis().ToggleCss(Css.Small, toggle);
        }

        public static Element<TModel> Lead<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator, "p", Css.Lead).SetText(text);
        }

        public static Element<TModel> Marked<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator, "mark", cssClasses).SetText(text);
        }

        public static Element<TModel> Deleted<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator, "del", cssClasses).SetText(text);
        }

        public static Element<TModel> Strikethrough<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator, "s", cssClasses).SetText(text);
        }

        public static Element<TModel> Inserted<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator, "ins", cssClasses).SetText(text);
        }

        public static Element<TModel> Underlined<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator, "u", cssClasses).SetText(text);
        }

        public static Element<TModel> Strong<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator, "strong", cssClasses).SetText(text);
        }

        public static Element<TModel> Bold<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator, "b", cssClasses).SetText(text);
        }

        public static Element<TModel> Emphasis<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator, "em", cssClasses).SetText(text);
        }

        public static Element<TModel> Italics<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator, "i", cssClasses).SetText(text);
        }

        // Text alignment and transformation

        public static TThis SetTextAlignment<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, TextAlignment alignment)
            where TThis : Tag<TModel, TThis, TWrapper>
            where TWrapper : TagWrapper<TModel>, new()
        {
            return component.GetThis().ToggleCss(alignment);
        }

        public static TThis SetTextTransformation<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, TextTransformation transformation)
            where TThis : Tag<TModel, TThis, TWrapper>
            where TWrapper : TagWrapper<TModel>, new()
        {
            return component.GetThis().ToggleCss(transformation);
        }

        // Abbreviation

        public static Abbr<TModel> Abbreviation<TModel>(this ITagCreator<TModel> creator, string title, string text, params string[] cssClasses)
        {
            return new Abbr<TModel>(creator, cssClasses).SetTitle(title).SetText(text);
        }

        public static Abbr<TModel> SetInitialism<TModel>(this Abbr<TModel> abbr, bool initialism = true)
        {
            return abbr.ToggleCss(Css.Initialism, initialism);
        }

        // Address

        public static Element<TModel> Address<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator, "address", cssClasses).SetText(text);
        }

        // Blockquote

        public static Blockquote<TModel> Blockquote<TModel>(this ITagCreator<TModel> creator, string quote = null, string footer = null, params string[] cssClasses)
        {
            return new Blockquote<TModel>(creator, cssClasses).SetQuote(quote).SetFooter(footer);
        }

        public static Blockquote<TModel> SetQuote<TModel>(this Blockquote<TModel> blockquote, string quote)
        {
            blockquote.Quote = quote;
            return blockquote;
        }

        public static Blockquote<TModel> SetFooter<TModel>(this Blockquote<TModel> blockquote, string footer)
        {
            blockquote.Footer = footer;
            return blockquote;
        }

        public static Blockquote<TModel> SetReverse<TModel>(this Blockquote<TModel> blockquote, bool reverse = true)
        {
            return blockquote.ToggleCss(Css.BlockquoteReverse, reverse);
        }

        public static Element<TModel> Footer<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator, "footer", cssClasses).SetText(text);
        }

        public static Cite<TModel> Cite<TModel>(this ITagCreator<TModel> creator, string title = null, string text = null, params string[] cssClasses)
        {
            return new Cite<TModel>(creator, cssClasses).SetTitle(title).SetText(text);
        }

        // List

        public static Typography.List<TModel> List<TModel>(this IListCreator<TModel> creator, ListType listType = ListType.Unstyled)
        {
            return new Typography.List<TModel>(creator, listType);
        }

        public static Typography.List<TModel> ListFor<TModel, TValue>(this IListCreator<TModel> creator, Expression<Func<TModel, IEnumerable<TValue>>> expression, Func<TValue, object> item, ListType listType = ListType.Unstyled)
        {
            Typography.List<TModel> list = new Typography.List<TModel>(creator, listType);
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
            return new ListItem<TModel>(creator).AddContent(content);
        }

        // DescriptionList

        public static DescriptionList<TModel> DescriptionList<TModel>(this IDescriptionListCreator<TModel> creator)
        {
            return new DescriptionList<TModel>(creator);
        }

        public static DescriptionList<TModel> SetHorizontal<TModel>(this DescriptionList<TModel> descriptionList, bool horizontal = true)
        {
            descriptionList.ToggleCss(Css.DlHorizontal, horizontal);
            return descriptionList;
        }

        public static DescriptionTerm<TModel> DescriptionTerm<TModel>(this IDescriptionTermCreator<TModel> creator, object content = null)
        {
            return new DescriptionTerm<TModel>(creator).AddContent(content);
        }

        public static Description<TModel> Description<TModel>(this IDescriptionCreator<TModel> creator, object content = null)
        {
            return new Description<TModel>(creator).AddContent(content);
        }

        // Code, etc.

        public static Element<TModel> Code<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator, "code", cssClasses).SetText(text);
        }

        public static Element<TModel> Keyboard<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator, "kbd", cssClasses).SetText(text);
        }

        public static Pre<TModel> Preformatted<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Pre<TModel>(creator, cssClasses).SetText(text);
        }

        public static Pre<TModel> SetScrollable<TModel>(this Pre<TModel> pre, bool scrollable = true)
        {
            return pre.ToggleCss(Css.PreScrollable, scrollable);
        }

        public static Element<TModel> Variable<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator, "var", cssClasses).SetText(text);
        }

        public static Element<TModel> Sample<TModel>(this ITagCreator<TModel> creator, string text = null, params string[] cssClasses)
        {
            return new Element<TModel>(creator, "samp", cssClasses).SetText(text);
        }
    }
}
