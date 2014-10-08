using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebPages;

namespace FluentBootstrap
{
    public static class TagExtensions
    {
        // Tag extensions
        public static TThis AddCss<TModel, TThis>(this Component<TModel, TThis> component, params string[] cssClasses)
            where TThis : Tag<TModel, TThis>
        {
            TThis tag = component.GetThis();
            foreach (string cssClass in cssClasses)
            {
                tag.CssClasses.Add(cssClass);
            }
            return tag;
        }

        public static TThis RemoveCss<TModel, TThis>(this Component<TModel, TThis> component, params string[] cssClasses)
            where TThis : Tag<TModel, TThis>
        {
            TThis tag = component.GetThis();
            foreach (string cssClass in cssClasses)
            {
                tag.CssClasses.Remove(cssClass);
            }
            return tag;
        }

        public static TThis Attributes<TModel, TThis>(this Component<TModel, TThis> component, object htmlAttributes)
            where TThis : Tag<TModel, TThis>
        {
            TThis tag = component.GetThis();
            tag.MergeAttributes(htmlAttributes);
            return tag;
        }

        public static TThis Attributes<TModel, TThis>(this Component<TModel, TThis> component, IDictionary<string, object> htmlAttributes)
            where TThis : Tag<TModel, TThis>
        {
            TThis tag = component.GetThis();
            tag.MergeAttributes(htmlAttributes);
            return tag;
        }

        public static TThis AddAttribute<TModel, TThis>(this Component<TModel, TThis> component, string key, object value)
            where TThis : Tag<TModel, TThis>
        {
            TThis tag = component.GetThis();
            tag.MergeAttribute(key, Convert.ToString(value, CultureInfo.InvariantCulture));
            return tag;
        }

        public static TThis Id<TModel, TThis>(this Component<TModel, TThis> component, string id)
            where TThis : Tag<TModel, TThis>
        {
            TThis tag = component.GetThis();
            tag.MergeAttribute("id", id);
            return tag;
        }

        public static TThis AddContent<TModel, TThis>(this Component<TModel, TThis> component, object content)
            where TThis : Tag<TModel, TThis>
        {
            TThis tag = component.GetThis();
            if (content != null)
            {
                // Make sure that this isn't a component
                Component contentComponent = content as Component;
                if (contentComponent != null)
                {
                    return AddChild(component, x => contentComponent);
                }

                // Now check if it's an IHtmlString
                string str;
                IHtmlString htmlString = content as IHtmlString;
                if (htmlString != null)
                {
                    str = htmlString.ToHtmlString();
                }
                else
                {
                    // Just convert to a string using the standard conversion logic
                    str = Convert.ToString(content, CultureInfo.InvariantCulture);
                }

                if (!string.IsNullOrEmpty(str))
                {
                    tag.AddChild(new Content<TModel>(tag.Helper, str));
                }
            }
            return tag;
        }
        
        public static TThis AddHtml<TModel, TThis>(this Component<TModel, TThis> component, Func<dynamic, HelperResult> content)
            where TThis : Tag<TModel, TThis>
        {
            TThis tag = component.GetThis();
            tag.AddChild(new Content<TModel>(tag.Helper,
                content(null).ToHtmlString()));
            return tag;
        }

        public static TThis AddChild<TThis, TChild, TModel>(this Component<TModel, TThis> component, Func<TThis, TChild> childFunc)
            where TThis : Tag<TModel, TThis>
            where TChild : Component
        {
            TThis tag = component.GetThis();
            TChild child = childFunc(tag);
            tag.AddChild(child);
            return tag;
        }

        // Responsive utilities

        public static TThis VisibleXsBlock<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.VisibleXsBlock, toggle);
        }

        public static TThis VisibleXsInline<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.VisibleXsInline, toggle);
        }

        public static TThis VisibleXsInlineBlock<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.VisibleXsInlineBlock, toggle);
        }

        public static TThis VisibleSmBlock<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.VisibleSmBlock, toggle);
        }

        public static TThis VisibleSmInline<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.VisibleSmInline, toggle);
        }

        public static TThis VisibleSmInlineBlock<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.VisibleSmInlineBlock, toggle);
        }

        public static TThis VisibleMdBlock<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.VisibleMdBlock, toggle);
        }

        public static TThis VisibleMdInline<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.VisibleMdInline, toggle);
        }

        public static TThis VisibleMdInlineBlock<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.VisibleMdInlineBlock, toggle);
        }

        public static TThis VisibleLgBlock<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.VisibleLgBlock, toggle);
        }

        public static TThis VisibleLgInline<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.VisibleLgInline, toggle);
        }

        public static TThis VisibleLgInlineBlock<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.VisibleLgInlineBlock, toggle);
        }

        public static TThis HiddenXs<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.HiddenXs, toggle);
        }

        public static TThis HiddenSm<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.HiddenSm, toggle);
        }

        public static TThis HiddenMd<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.HiddenMd, toggle);
        }

        public static TThis HiddenLg<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.HiddenLg, toggle);
        }

        // Print classes

        public static TThis VisiblePrintBlock<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.VisiblePrintBlock, toggle);
        }

        public static TThis VisiblePrintInline<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.VisiblePrintInline, toggle);
        }

        public static TThis VisiblePrintInlineBlock<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.VisiblePrintInlineBlock, toggle);
        }

        public static TThis HiddenPrint<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.HiddenPrint, toggle);
        }


        // Contextual colors

        public static TThis TextMuted<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.TextMuted, toggle);
        }

        public static TThis TextPrimary<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.TextPrimary, toggle);
        }

        public static TThis TextSuccess<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.TextSuccess, toggle);
        }

        public static TThis TextInfo<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.TextInfo, toggle);
        }

        public static TThis TextWarning<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.TextWarning, toggle);
        }

        public static TThis TextDanger<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.TextDanger, toggle);
        }

        // Contextual backgrounds

        public static TThis BgPrimary<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.BgPrimary, toggle);
        }

        public static TThis BgSuccess<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.BgSuccess, toggle);
        }

        public static TThis BgInfo<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.BgInfo, toggle);
        }

        public static TThis BgWarning<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.BgWarning, toggle);
        }

        public static TThis BgDanger<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.BgDanger, toggle);
        }

        // Showing and hiding content

        public static TThis Show<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.Show, toggle);
        }

        public static TThis Hidden<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.Hidden, toggle);
        }

        public static TThis Invisible<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.Invisible, toggle);
        }

        // Screen reader

        public static TThis SrOnly<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.SrOnly, toggle);
        }

        public static TThis SrOnlyFocusable<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.SrOnlyFocusable, toggle);
        }

        // Image replacement

        public static TThis TextHide<TModel, TThis>(this Component<TModel, TThis> component, bool toggle = true)
            where TThis : Tag<TModel, TThis>
        {
            return component.GetThis().ToggleCss(Css.TextHide, toggle);
        }


    }
}
