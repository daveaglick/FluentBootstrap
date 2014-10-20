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
        public static TThis AddCss<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, params string[] cssClasses)
            where TThis : Tag<TModel, TThis, TWrapper>
            where TWrapper : TagWrapper<TModel>, new()
        {
            TThis tag = component.GetThis();
            foreach (string cssClass in cssClasses)
            {
                tag.CssClasses.Add(cssClass);
            }
            return tag;
        }

        public static TThis RemoveCss<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, params string[] cssClasses)
            where TThis : Tag<TModel, TThis, TWrapper>
            where TWrapper : TagWrapper<TModel>, new()
        {
            TThis tag = component.GetThis();
            foreach (string cssClass in cssClasses)
            {
                tag.CssClasses.Remove(cssClass);
            }
            return tag;
        }

        public static TThis AddAttributes<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, object htmlAttributes)
            where TThis : Tag<TModel, TThis, TWrapper>
            where TWrapper : TagWrapper<TModel>, new()
        {
            return component.GetThis().MergeAttributes(htmlAttributes);
        }

        public static TThis AddAttributes<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, IDictionary<string, object> htmlAttributes)
            where TThis : Tag<TModel, TThis, TWrapper>
            where TWrapper : TagWrapper<TModel>, new()
        {
            return component.GetThis().MergeAttributes(htmlAttributes);
        }

        public static TThis AddAttribute<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, string key, object value)
            where TThis : Tag<TModel, TThis, TWrapper>
            where TWrapper : TagWrapper<TModel>, new()
        {
            return component.GetThis().MergeAttribute(key, Convert.ToString(value, CultureInfo.InvariantCulture));
        }

        public static TThis SetId<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, string id)
            where TThis : Tag<TModel, TThis, TWrapper>
            where TWrapper : TagWrapper<TModel>, new()
        {
            return component.GetThis().MergeAttribute("id", id);
        }

        public static TThis AddContent<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, object content)
            where TThis : Tag<TModel, TThis, TWrapper>
            where TWrapper : TagWrapper<TModel>, new()
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

        public static TThis AddHtml<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, Func<dynamic, HelperResult> content)
            where TThis : Tag<TModel, TThis, TWrapper>
            where TWrapper : TagWrapper<TModel>, new()
        {
            TThis tag = component.GetThis();
            tag.AddChild(new Content<TModel>(tag.Helper,
                content(null).ToHtmlString()));
            return tag;
        }

        public static TThis AddChild<TModel, TThis, TChild, TWrapper>(this Component<TModel, TThis, TWrapper> component, Func<TWrapper, TChild> childFunc)
            where TThis : Tag<TModel, TThis, TWrapper>
            where TWrapper : TagWrapper<TModel>, new()
            where TChild : Component
        {
            TThis tag = component.GetThis();
            tag.AddChild(childFunc(tag.GetWrapper()));
            return tag;
        }

        // This is a very special extension - it allows adding a child using fluent style and switches the current chaining object to the child
        // behind the scenes the parent start is immediately output and the child ends the parent when it ends (so that the while hierarchy gets output)
        public static TWrapper WithChild<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component)
            where TThis : Tag<TModel, TThis, TWrapper>
            where TWrapper : TagWrapper<TModel>, new()
        {
            TThis tag = component.GetThis();
            TWrapper wrapper = tag.Begin();
            wrapper.WithChild = true;
            return wrapper;
        }

        public static TThis SetVisibility<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, Visibility visibility)
            where TThis : Tag<TModel, TThis, TWrapper>
            where TWrapper : TagWrapper<TModel>, new()
        {
            return component.GetThis().ToggleCss(visibility);
        }

        public static TThis SetState<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, TextState state)
            where TThis : Tag<TModel, TThis, TWrapper>
            where TWrapper : TagWrapper<TModel>, new()
        {
            return component.GetThis().ToggleCss(state);
        }

        public static TThis SetBackgroundState<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, BackgroundState backgroundState)
            where TThis : Tag<TModel, TThis, TWrapper>
            where TWrapper : TagWrapper<TModel>, new()
        {
            return component.GetThis().ToggleCss(backgroundState);
        }
    }
}
