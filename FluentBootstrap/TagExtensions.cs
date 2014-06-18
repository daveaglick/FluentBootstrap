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
        public static TTag CssClass<TTag, TModel>(this TTag tag, params string[] cssClasses)
            where TTag : Tag<TModel>
        {
            foreach (string cssClass in cssClasses)
            {
                tag.CssClasses.Add(cssClass);
            }
            return tag;
        }

        public static TTag HtmlAttributes<TTag, TModel>(this TTag tag, object htmlAttributes)
            where TTag : Tag<TModel>
        {
            tag.MergeAttributes(htmlAttributes);
            return tag;
        }

        public static TTag HtmlAttributes<TTag, TModel>(this TTag tag, IDictionary<string, object> htmlAttributes)
            where TTag : Tag<TModel>
        {
            tag.MergeAttributes(htmlAttributes);
            return tag;
        }

        public static TTag HtmlAttribute<TTag, TModel>(this TTag tag, string key, object value)
            where TTag : Tag<TModel>
        {
            tag.MergeAttribute(key, Convert.ToString(value, CultureInfo.InvariantCulture));
            return tag;
        }

        public static TTag Content<TTag, TModel>(this TTag tag, object content)
            where TTag : Tag<TModel>
        {
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
        
        public static TTag Html<TTag, TModel>(this TTag tag, Func<dynamic, HelperResult> content)
            where TTag : Tag<TModel>
        {
            tag.AddChild(new Content<TModel>(tag.Helper,
                content(null).ToHtmlString()));
            return tag;
        }

        public static TTag Child<TTag, TChild, TModel>(this TTag tag, Func<TTag, TChild> childFunc)
            where TTag : Tag<TModel>
            where TChild : Component<TModel>
        {
            TChild child = childFunc(tag);
            tag.AddChild(child);
            return tag;
        }
    }
}
