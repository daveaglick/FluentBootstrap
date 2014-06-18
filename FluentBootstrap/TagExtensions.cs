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
        public static TTag CssClass<TTag>(this TTag tag, params string[] cssClasses)
            where TTag : Tag
        {
            foreach (string cssClass in cssClasses)
            {
                tag.CssClasses.Add(cssClass);
            }
            return tag;
        }

        public static TTag HtmlAttributes<TTag>(this TTag tag, object htmlAttributes)
            where TTag : Tag
        {
            tag.MergeAttributes(htmlAttributes);
            return tag;
        }

        public static TTag HtmlAttributes<TTag>(this TTag tag, IDictionary<string, object> htmlAttributes)
            where TTag : Tag
        {
            tag.MergeAttributes(htmlAttributes);
            return tag;
        }

        public static TTag HtmlAttribute<TTag>(this TTag tag, string key, object value)
            where TTag : Tag
        {
            tag.MergeAttribute(key, Convert.ToString(value, CultureInfo.InvariantCulture));
            return tag;
        }

        public static TTag Content<TTag>(this TTag tag, object content)
            where TTag : Tag
        {
            if (content != null)
            {
                string str = Convert.ToString(content, CultureInfo.InvariantCulture);
                if (!string.IsNullOrEmpty(str))
                {
                    tag.AddChild(new Content(tag.Helper, str));
                }
            }
            return tag;
        }
        
        public static TTag Html<TTag>(this TTag tag, Func<dynamic, HelperResult> content)
            where TTag : Tag
        {
            tag.AddChild(new Content(tag.Helper,
                content(null).ToHtmlString()));
            return tag;
        }

        public static TTag Child<TTag, TChild>(this TTag tag, Func<TTag, TChild> childFunc)
            where TTag : Tag
            where TChild : Component
        {
            TChild child = childFunc(tag);
            tag.AddChild(child);
            return tag;
        }
    }
}
