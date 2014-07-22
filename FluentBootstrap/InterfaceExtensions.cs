using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    // These are extensions for general interfaces
    public static class InterfaceExtensions
    {
        // IHasDisabledAttribute

        public static TThis Disabled<TModel, TThis>(this Component<TModel, TThis> component, bool disabled = true)
            where TThis : Tag<TModel, TThis>, IHasDisabledAttribute
        {
            TThis tag = component.GetThis();
            tag.MergeAttribute("disabled", disabled ? "disabled" : null);
            return tag;
        }

        // IHasTextAttribute

        public static TThis Text<TModel, TThis>(this Component<TModel, TThis> component, string text)
            where TThis : Tag<TModel, TThis>, IHasTextAttribute
        {
            TThis tag = component.GetThis();
            tag.TextContent = text;
            return tag;
        }

        // IHasValueAttribute

        public static TThis Value<TModel, TThis>(this Component<TModel, TThis> component, object value, string format = null)
            where TThis : Tag<TModel, TThis>, IHasValueAttribute
        {
            TThis tag = component.GetThis();
            tag.MergeAttribute("value", value == null ? null : component.HtmlHelper.FormatValue(value, format));
            return tag;
        }

        // IHasNameAttribute

        public static TThis Name<TModel, TThis>(this Component<TModel, TThis> component, string name)
            where TThis : Tag<TModel, TThis>, IHasNameAttribute
        {
            TThis tag = component.GetThis();
            tag.MergeAttribute("name", name == null ? null : tag.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name));
            return tag;
        }

        internal static string GetName<TModel, TThis>(this Component<TModel, TThis> component)
            where TThis : Tag<TModel, TThis>
        {
            TThis tag = component.GetThis();
            string name;
            if (!tag.TagBuilder.Attributes.TryGetValue("name", out name))
            {
                name = null; 
            }
            return name;
        }

        // IHasTitleAttribute

        public static TThis Title<TModel, TThis>(this Component<TModel, TThis> component, object title, string format = null)
            where TThis : Tag<TModel, TThis>, IHasTitleAttribute
        {
            TThis tag = component.GetThis();
            tag.MergeAttribute("title", title == null ? null : component.HtmlHelper.FormatValue(title, format));
            return tag;
        }
    }
}
