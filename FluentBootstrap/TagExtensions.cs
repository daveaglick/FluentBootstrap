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
        public static TThis AddCss<TModel, TThis, TParent>(this Component<TModel, TThis, TParent> component, params string[] cssClasses)
            where TThis : Tag<TModel, TThis, TParent>
            where TParent : TagParent<TModel>, new()
        {
            TThis tag = component.GetThis();
            foreach (string cssClass in cssClasses)
            {
                tag.CssClasses.Add(cssClass);
            }
            return tag;
        }

        public static TThis RemoveCss<TModel, TThis, TParent>(this Component<TModel, TThis, TParent> component, params string[] cssClasses)
            where TThis : Tag<TModel, TThis, TParent>
            where TParent : TagParent<TModel>, new()
        {
            TThis tag = component.GetThis();
            foreach (string cssClass in cssClasses)
            {
                tag.CssClasses.Remove(cssClass);
            }
            return tag;
        }

        public static TThis AddAttributes<TModel, TThis, TParent>(this Component<TModel, TThis, TParent> component, object htmlAttributes)
            where TThis : Tag<TModel, TThis, TParent>
            where TParent : TagParent<TModel>, new()
        {
            return component.GetThis().MergeAttributes(htmlAttributes);
        }

        public static TThis AddAttributes<TModel, TThis, TParent>(this Component<TModel, TThis, TParent> component, IDictionary<string, object> htmlAttributes)
            where TThis : Tag<TModel, TThis, TParent>
            where TParent : TagParent<TModel>, new()
        {
            return component.GetThis().MergeAttributes(htmlAttributes);
        }

        public static TThis AddAttribute<TModel, TThis, TParent>(this Component<TModel, TThis, TParent> component, string key, object value)
            where TThis : Tag<TModel, TThis, TParent>
            where TParent : TagParent<TModel>, new()
        {
            return component.GetThis().MergeAttribute(key, Convert.ToString(value, CultureInfo.InvariantCulture));
        }

        public static TThis SetId<TModel, TThis, TParent>(this Component<TModel, TThis, TParent> component, string id)
            where TThis : Tag<TModel, TThis, TParent>
            where TParent : TagParent<TModel>, new()
        {
            return component.GetThis().MergeAttribute("id", id);
        }

        public static TThis AddContent<TModel, TThis, TParent>(this Component<TModel, TThis, TParent> component, object content)
            where TThis : Tag<TModel, TThis, TParent>
            where TParent : TagParent<TModel>, new()
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

        public static TThis AddHtml<TModel, TThis, TParent>(this Component<TModel, TThis, TParent> component, Func<dynamic, HelperResult> content)
            where TThis : Tag<TModel, TThis, TParent>
            where TParent : TagParent<TModel>, new()
        {
            TThis tag = component.GetThis();
            tag.AddChild(new Content<TModel>(tag.Helper,
                content(null).ToHtmlString()));
            return tag;
        }

        public static TThis AddChild<TModel, TThis, TChild, TParent>(this Component<TModel, TThis, TParent> component, Func<TParent, TChild> childFunc)
            where TThis : Tag<TModel, TThis, TParent>
            where TParent : TagParent<TModel>, new()
            where TChild : Component
        {
            TThis tag = component.GetThis();
            tag.AddChild(childFunc(tag.GetParent()));
            return tag;
        }

        // This is a very special extension - it allows adding a child using fluent style and switches the fluent object to the child, but behind the scenes
        // will still defer all rendering calls to the parent (so that the while hierarchy gets output at once, starting with the parent)
        public static TParent WithChild<TModel, TThis, TParent>(this Component<TModel, TThis, TParent> component)
            where TThis : Tag<TModel, TThis, TParent>
            where TParent : TagParent<TModel>, new()
        {
            TThis tag = component.GetThis();
            TParent parent = tag.GetParent();
            parent.WithChild = true;
            return parent;
        }

        public static TThis SetVisibility<TModel, TThis, TParent>(this Component<TModel, TThis, TParent> component, Visibility visibility)
            where TThis : Tag<TModel, TThis, TParent>
            where TParent : TagParent<TModel>, new()
        {
            return component.GetThis().ToggleCss(visibility);
        }

        public static TThis SetTextColor<TModel, TThis, TParent>(this Component<TModel, TThis, TParent> component, TextColor textColor)
            where TThis : Tag<TModel, TThis, TParent>
            where TParent : TagParent<TModel>, new()
        {
            return component.GetThis().ToggleCss(textColor);
        }

        public static TThis SetBackgroundColor<TModel, TThis, TParent>(this Component<TModel, TThis, TParent> component, BackgroundColor backgroundColor)
            where TThis : Tag<TModel, TThis, TParent>
            where TParent : TagParent<TModel>, new()
        {
            return component.GetThis().ToggleCss(backgroundColor);
        }
    }
}
