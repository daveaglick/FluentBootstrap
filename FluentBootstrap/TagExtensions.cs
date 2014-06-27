using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages;

namespace FluentBootstrap
{
    public static class TagExtensions
    {
        public static TThis AddCssClass<TModel, TThis>(this Component<TModel, TThis> component, params string[] cssClasses)
            where TThis : Tag<TModel, TThis>
        {
            TThis tag = component.GetThis();
            foreach (string cssClass in cssClasses)
            {
                tag.CssClasses.Add(cssClass);
            }
            return tag;
        }

        public static TThis RemoveCssClass<TModel, TThis>(this Component<TModel, TThis> component, params string[] cssClasses)
            where TThis : Tag<TModel, TThis>
        {
            TThis tag = component.GetThis();
            foreach (string cssClass in cssClasses)
            {
                tag.CssClasses.Remove(cssClass);
            }
            return tag;
        }

        public static TThis HtmlAttributes<TModel, TThis>(this Component<TModel, TThis> component, object htmlAttributes)
            where TThis : Tag<TModel, TThis>
        {
            TThis tag = component.GetThis();
            tag.MergeAttributes(htmlAttributes);
            return tag;
        }

        public static TThis HtmlAttributes<TModel, TThis>(this Component<TModel, TThis> component, IDictionary<string, object> htmlAttributes)
            where TThis : Tag<TModel, TThis>
        {
            TThis tag = component.GetThis();
            tag.MergeAttributes(htmlAttributes);
            return tag;
        }

        public static TThis AddHtmlAttribute<TModel, TThis>(this Component<TModel, TThis> component, string key, object value)
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
                string str = Convert.ToString(content, CultureInfo.InvariantCulture);
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
    }
}
