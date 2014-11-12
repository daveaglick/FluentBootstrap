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

        public static Heading<THelper> Heading1<THelper>(this IHeadingCreator<THelper> creator, string text = null)
        {
            return new Heading<THelper>(creator, "h1").SetText(text);
        }

        public static Heading<THelper> Heading2<THelper>(this IHeadingCreator<THelper> creator, string text = null)
        {
            return new Heading<THelper>(creator, "h2").SetText(text);
        }

        public static Heading<THelper> Heading3<THelper>(this IHeadingCreator<THelper> creator, string text = null)
        {
            return new Heading<THelper>(creator, "h3").SetText(text);
        }

        public static Heading<THelper> Heading4<THelper>(this IHeadingCreator<THelper> creator, string text = null)
        {
            return new Heading<THelper>(creator, "h4").SetText(text);
        }

        public static Heading<THelper> Heading5<THelper>(this IHeadingCreator<THelper> creator, string text = null)
        {
            return new Heading<THelper>(creator, "h5").SetText(text);
        }

        public static Heading<THelper> Heading6<THelper>(this IHeadingCreator<THelper> creator, string text = null)
        {
            return new Heading<THelper>(creator, "h6").SetText(text);
        }

        public static TThis SetSmallText<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, string text)
            where TThis : Heading<THelper, TThis, TWrapper>
            where TWrapper : HeadingWrapper<THelper>, new()
        {
            TThis heading = component.GetThis();
            heading.SmallText = text;
            return heading;
        }

        // Body copy

        public static Small<THelper> Small<THelper>(this ISmallCreator<THelper> creator, string text = null)
        {
            return new Small<THelper>(creator).SetText(text);
        }

        public static TThis SetSmall<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, bool toggle = true)
            where TThis : Tag<THelper, TThis, TWrapper>
            where TWrapper : TagWrapper<THelper>, new()
        {
            return component.GetThis().ToggleCss(Css.Small, toggle);
        }

        public static Element<THelper> Lead<THelper>(this ITagCreator<THelper> creator, string text = null)
        {
            return new Element<THelper>(creator, "p", Css.Lead).SetText(text);
        }

        public static Element<THelper> Marked<THelper>(this ITagCreator<THelper> creator, string text = null)
        {
            return new Element<THelper>(creator, "mark").SetText(text);
        }

        public static Element<THelper> Deleted<THelper>(this ITagCreator<THelper> creator, string text = null)
        {
            return new Element<THelper>(creator, "del").SetText(text);
        }

        public static Element<THelper> Strikethrough<THelper>(this ITagCreator<THelper> creator, string text = null)
        {
            return new Element<THelper>(creator, "s").SetText(text);
        }

        public static Element<THelper> Inserted<THelper>(this ITagCreator<THelper> creator, string text = null)
        {
            return new Element<THelper>(creator, "ins").SetText(text);
        }

        public static Element<THelper> Underlined<THelper>(this ITagCreator<THelper> creator, string text = null)
        {
            return new Element<THelper>(creator, "u").SetText(text);
        }

        public static Element<THelper> Strong<THelper>(this ITagCreator<THelper> creator, string text = null)
        {
            return new Element<THelper>(creator, "strong").SetText(text);
        }

        public static Element<THelper> Bold<THelper>(this ITagCreator<THelper> creator, string text = null)
        {
            return new Element<THelper>(creator, "b").SetText(text);
        }

        public static Element<THelper> Emphasis<THelper>(this ITagCreator<THelper> creator, string text = null)
        {
            return new Element<THelper>(creator, "em").SetText(text);
        }

        public static Element<THelper> Italics<THelper>(this ITagCreator<THelper> creator, string text = null)
        {
            return new Element<THelper>(creator, "i").SetText(text);
        }

        // Text alignment and transformation

        public static TThis SetAlignment<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, TextAlignment alignment)
            where TThis : Tag<THelper, TThis, TWrapper>
            where TWrapper : TagWrapper<THelper>, new()
        {
            return component.GetThis().ToggleCss(alignment);
        }

        public static TThis SetTransformation<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, TextTransformation transformation)
            where TThis : Tag<THelper, TThis, TWrapper>
            where TWrapper : TagWrapper<THelper>, new()
        {
            return component.GetThis().ToggleCss(transformation);
        }

        // Abbreviation

        public static Abbr<THelper> Abbreviation<THelper>(this ITagCreator<THelper> creator, string title, string text)
        {
            return new Abbr<THelper>(creator).SetTitle(title).SetText(text);
        }

        public static Abbr<THelper> SetInitialism<THelper>(this Abbr<THelper> abbr, bool initialism = true)
        {
            return abbr.ToggleCss(Css.Initialism, initialism);
        }

        // Address

        public static Element<THelper> Address<THelper>(this ITagCreator<THelper> creator, string text = null)
        {
            return new Element<THelper>(creator, "address").SetText(text);
        }

        // Blockquote

        public static Blockquote<THelper> Blockquote<THelper>(this ITagCreator<THelper> creator, string quote = null, string footer = null)
        {
            return new Blockquote<THelper>(creator).SetQuote(quote).SetFooter(footer);
        }

        public static Blockquote<THelper> SetQuote<THelper>(this Blockquote<THelper> blockquote, string quote)
        {
            blockquote.Quote = quote;
            return blockquote;
        }

        public static Blockquote<THelper> SetFooter<THelper>(this Blockquote<THelper> blockquote, string footer)
        {
            blockquote.Footer = footer;
            return blockquote;
        }

        public static Blockquote<THelper> SetReverse<THelper>(this Blockquote<THelper> blockquote, bool reverse = true)
        {
            return blockquote.ToggleCss(Css.BlockquoteReverse, reverse);
        }

        public static Element<THelper> Footer<THelper>(this ITagCreator<THelper> creator, string text = null)
        {
            return new Element<THelper>(creator, "footer").SetText(text);
        }

        public static Cite<THelper> Cite<THelper>(this ITagCreator<THelper> creator, string title = null, string text = null)
        {
            return new Cite<THelper>(creator).SetTitle(title).SetText(text);
        }

        // List

        public static Typography.List<THelper> List<THelper>(this IListCreator<THelper> creator, ListType listType = ListType.Unstyled)
        {
            return new Typography.List<THelper>(creator, listType);
        }

        public static Typography.List<THelper> ListFor<THelper, TValue>(this IListCreator<THelper> creator, Expression<Func<THelper, IEnumerable<TValue>>> expression, Func<TValue, object> item, ListType listType = ListType.Unstyled)
        {
            Typography.List<THelper> list = new Typography.List<THelper>(creator, listType);
            IEnumerable<TValue> values = ModelMetadata.FromLambdaExpression(expression, list.Helper.HtmlHelper.ViewData).Model as IEnumerable<TValue>;
            if (values != null)
            {
                foreach (TValue value in values)
                {
                    list.AddChild(x => x.ListItem(item(value)));
                }
            }
            return list;
        }

        public static ListItem<THelper> ListItem<THelper>(this IListItemCreator<THelper> creator, object content = null)
        {
            return new ListItem<THelper>(creator).AddContent(content);
        }

        // DescriptionList

        public static DescriptionList<THelper> DescriptionList<THelper>(this IDescriptionListCreator<THelper> creator)
        {
            return new DescriptionList<THelper>(creator);
        }

        public static DescriptionList<THelper> SetHorizontal<THelper>(this DescriptionList<THelper> descriptionList, bool horizontal = true)
        {
            descriptionList.ToggleCss(Css.DlHorizontal, horizontal);
            return descriptionList;
        }

        public static DescriptionTerm<THelper> DescriptionTerm<THelper>(this IDescriptionTermCreator<THelper> creator, object content = null)
        {
            return new DescriptionTerm<THelper>(creator).AddContent(content);
        }

        public static Description<THelper> Description<THelper>(this IDescriptionCreator<THelper> creator, object content = null)
        {
            return new Description<THelper>(creator).AddContent(content);
        }

        // Code, etc.

        public static Element<THelper> Code<THelper>(this ITagCreator<THelper> creator, string text = null)
        {
            return new Element<THelper>(creator, "code").SetText(text);
        }

        public static Element<THelper> Keyboard<THelper>(this ITagCreator<THelper> creator, string text = null)
        {
            return new Element<THelper>(creator, "kbd").SetText(text);
        }

        public static Pre<THelper> Preformatted<THelper>(this ITagCreator<THelper> creator, string text = null)
        {
            return new Pre<THelper>(creator).SetText(text);
        }

        public static Pre<THelper> SetScrollable<THelper>(this Pre<THelper> pre, bool scrollable = true)
        {
            return pre.ToggleCss(Css.PreScrollable, scrollable);
        }

        public static Element<THelper> Variable<THelper>(this ITagCreator<THelper> creator, string text = null)
        {
            return new Element<THelper>(creator, "var").SetText(text);
        }

        public static Element<THelper> Sample<THelper>(this ITagCreator<THelper> creator, string text = null)
        {
            return new Element<THelper>(creator, "samp").SetText(text);
        }
    }
}
