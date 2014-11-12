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

        public static TThis Disable<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, bool disable = true)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasDisabledAttribute
            where TWrapper : TagWrapper<THelper>, new()
        {
            return component.GetThis().MergeAttribute("disabled", disable ? "disabled" : null);
        }

        // IHasTextContent

        public static TThis SetText<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, string text)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasTextContent
            where TWrapper : TagWrapper<THelper>, new()
        {
            TThis tag = component.GetThis();
            tag.TextContent = text;
            return tag;
        }

        // IHasValueAttribute

        public static TThis SetValue<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, object value, string format = null)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasValueAttribute
            where TWrapper : TagWrapper<THelper>, new()
        {
            TThis tag = component.GetThis();
            tag.MergeAttribute("value", value == null ? null : component.HtmlHelper.FormatValue(value, format));
            return tag;
        }

        // IHasNameAttribute

        public static TThis SetName<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, string name)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasNameAttribute
            where TWrapper : TagWrapper<THelper>, new()
        {
            TThis tag = component.GetThis();
            tag.MergeAttribute("name", name == null ? null : tag.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name));
            return tag;
        }

        internal static string GetName<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>
            where TWrapper : TagWrapper<THelper>, new()
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

        public static TThis SetTitle<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, object title, string format = null)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasTitleAttribute
            where TWrapper : TagWrapper<THelper>, new()
        {
            TThis tag = component.GetThis();
            tag.MergeAttribute("title", title == null ? null : component.HtmlHelper.FormatValue(title, format));
            return tag;
        }
    }
}
