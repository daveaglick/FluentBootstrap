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
        public static TThis AddCss<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, params string[] cssClasses)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>
            where TWrapper : TagWrapper<THelper>, new()
        {
            TThis tag = component.GetThis();
            foreach (string cssClass in cssClasses)
            {
                tag.CssClasses.Add(cssClass);
            }
            return tag;
        }

        public static TThis RemoveCss<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, params string[] cssClasses)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>
            where TWrapper : TagWrapper<THelper>, new()
        {
            TThis tag = component.GetThis();
            foreach (string cssClass in cssClasses)
            {
                tag.CssClasses.Remove(cssClass);
            }
            return tag;
        }

        public static TThis AddAttributes<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, object htmlAttributes)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>
            where TWrapper : TagWrapper<THelper>, new()
        {
            return component.GetThis().MergeAttributes(htmlAttributes);
        }

        public static TThis AddAttributes<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, IDictionary<string, object> htmlAttributes)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>
            where TWrapper : TagWrapper<THelper>, new()
        {
            return component.GetThis().MergeAttributes(htmlAttributes);
        }

        public static TThis AddAttribute<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, string attributeName, object value)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>
            where TWrapper : TagWrapper<THelper>, new()
        {
            return component.GetThis().MergeAttribute(attributeName, Convert.ToString(value, CultureInfo.InvariantCulture));
        }

        public static TThis AddStyles<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, object inlineStyles)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>
            where TWrapper : TagWrapper<THelper>, new()
        {
            return component.GetThis().MergeStyles(inlineStyles);
        }

        public static TThis AddStyles<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, IDictionary<string, object> inlineStyles)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>
            where TWrapper : TagWrapper<THelper>, new()
        {
            return component.GetThis().MergeStyles(inlineStyles);
        }

        public static TThis AddStyle<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, string inlineStyle, object value)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>
            where TWrapper : TagWrapper<THelper>, new()
        {
            return component.GetThis().MergeStyle(inlineStyle, Convert.ToString(value, CultureInfo.InvariantCulture));
        }

        public static TThis SetId<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, string id)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>
            where TWrapper : TagWrapper<THelper>, new()
        {
            return component.GetThis().MergeAttribute("id", id);
        }

        public static TThis AddContent<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, object content)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>
            where TWrapper : TagWrapper<THelper>, new()
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
                    tag.AddChild(new Content<THelper>(tag.Helper, str));
                }
            }
            return tag;
        }

        public static TThis AddHtml<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, Func<dynamic, HelperResult> content)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>
            where TWrapper : TagWrapper<THelper>, new()
        {
            TThis tag = component.GetThis();
            tag.AddChild(new Content<THelper>(tag.Helper,
                content(null).ToHtmlString()));
            return tag;
        }

        public static TThis AddChild<THelper, TThis, TChild, TWrapper>(this Component<THelper, TThis, TWrapper> component, Func<TWrapper, TChild> childFunc)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>
            where TWrapper : TagWrapper<THelper>, new()
            where TChild : Component
        {
            TThis tag = component.GetThis();
            tag.AddChild(childFunc(tag.GetWrapper()));
            return tag;
        }

        // This is a very special extension - it allows adding a child using fluent style and switches the current chaining object to the child
        // behind the scenes the parent start is immediately output and the child ends the parent when it ends (so that the while hierarchy gets output)
        public static TWrapper WithChild<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>
            where TWrapper : TagWrapper<THelper>, new()
        {
            TThis tag = component.GetThis();
            TWrapper wrapper = tag.Begin();
            wrapper.WithChild = true;
            return wrapper;
        }

        public static TThis SetVisibility<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, Visibility visibility)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>
            where TWrapper : TagWrapper<THelper>, new()
        {
            return component.GetThis().ToggleCss(visibility);
        }

        public static TThis SetState<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, TextState state)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>
            where TWrapper : TagWrapper<THelper>, new()
        {
            return component.GetThis().ToggleCss(state);
        }

        public static TThis SetBackgroundState<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, BackgroundState backgroundState)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>
            where TWrapper : TagWrapper<THelper>, new()
        {
            return component.GetThis().ToggleCss(backgroundState);
        }
    }
}
