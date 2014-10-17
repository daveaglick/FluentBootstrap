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

        public static TThis Disable<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, bool disable = true)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasDisabledAttribute
            where TWrapper : TagWrapper<TModel>, new()
        {
            return component.GetThis().MergeAttribute("disabled", disable ? "disabled" : null);
        }

        // IHasTextAttribute

        public static TThis SetText<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, string text)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasTextAttribute
            where TWrapper : TagWrapper<TModel>, new()
        {
            TThis tag = component.GetThis();
            tag.TextContent = text;
            return tag;
        }

        // IHasValueAttribute

        public static TThis SetValue<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, object value, string format = null)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasValueAttribute
            where TWrapper : TagWrapper<TModel>, new()
        {
            TThis tag = component.GetThis();
            tag.MergeAttribute("value", value == null ? null : component.HtmlHelper.FormatValue(value, format));
            return tag;
        }

        // IHasNameAttribute

        public static TThis SetName<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, string name)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasNameAttribute
            where TWrapper : TagWrapper<TModel>, new()
        {
            TThis tag = component.GetThis();
            tag.MergeAttribute("name", name == null ? null : tag.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name));
            return tag;
        }

        internal static string GetName<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component)
            where TThis : Tag<TModel, TThis, TWrapper>
            where TWrapper : TagWrapper<TModel>, new()
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

        public static TThis SetTitle<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, object title, string format = null)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasTitleAttribute
            where TWrapper : TagWrapper<TModel>, new()
        {
            TThis tag = component.GetThis();
            tag.MergeAttribute("title", title == null ? null : component.HtmlHelper.FormatValue(title, format));
            return tag;
        }
    }
}
