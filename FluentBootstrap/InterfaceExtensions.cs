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

        public static TThis Disable<TModel, TThis, TParent>(this Component<TModel, TThis, TParent> component, bool disable = true)
            where TThis : Tag<TModel, TThis, TParent>, IHasDisabledAttribute
            where TParent : TagParent<TModel>, new()
        {
            return component.GetThis().MergeAttribute("disabled", disable ? "disabled" : null);
        }

        // IHasTextAttribute

        public static TThis SetText<TModel, TThis, TParent>(this Component<TModel, TThis, TParent> component, string text)
            where TThis : Tag<TModel, TThis, TParent>, IHasTextAttribute
            where TParent : TagParent<TModel>, new()
        {
            TThis tag = component.GetThis();
            tag.TextContent = text;
            return tag;
        }

        // IHasValueAttribute

        public static TThis SetValue<TModel, TThis, TParent>(this Component<TModel, TThis, TParent> component, object value, string format = null)
            where TThis : Tag<TModel, TThis, TParent>, IHasValueAttribute
            where TParent : TagParent<TModel>, new()
        {
            TThis tag = component.GetThis();
            tag.MergeAttribute("value", value == null ? null : component.HtmlHelper.FormatValue(value, format));
            return tag;
        }

        // IHasNameAttribute

        public static TThis SetName<TModel, TThis, TParent>(this Component<TModel, TThis, TParent> component, string name)
            where TThis : Tag<TModel, TThis, TParent>, IHasNameAttribute
            where TParent : TagParent<TModel>, new()
        {
            TThis tag = component.GetThis();
            tag.MergeAttribute("name", name == null ? null : tag.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name));
            return tag;
        }

        internal static string GetName<TModel, TThis, TParent>(this Component<TModel, TThis, TParent> component)
            where TThis : Tag<TModel, TThis, TParent>
            where TParent : TagParent<TModel>, new()
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

        public static TThis SetTitle<TModel, TThis, TParent>(this Component<TModel, TThis, TParent> component, object title, string format = null)
            where TThis : Tag<TModel, TThis, TParent>, IHasTitleAttribute
            where TParent : TagParent<TModel>, new()
        {
            TThis tag = component.GetThis();
            tag.MergeAttribute("title", title == null ? null : component.HtmlHelper.FormatValue(title, format));
            return tag;
        }
    }
}
