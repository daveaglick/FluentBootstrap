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
        public static TThis Disabled<TModel, TThis>(this Component<TModel, TThis> component, bool disabled = true)
            where TThis : Tag<TModel, TThis>, IHasDisabledAttribute
        {
            TThis tag = component.GetThis();
            tag.MergeAttribute("disabled", disabled ? "disabled" : null);
            return tag;
        }

        public static TThis Text<TModel, TThis>(this Component<TModel, TThis> component, string text)
            where TThis : Tag<TModel, TThis>, IHasTextAttribute
        {
            TThis tag = component.GetThis();
            tag.TextContent = text;
            return tag;
        }

        public static TThis Value<TModel, TThis>(this Component<TModel, TThis> component, object value, string format = null)
            where TThis : Tag<TModel, TThis>, IHasValueAttribute
        {
            TThis tag = component.GetThis();
            tag.MergeAttribute("value", value == null ? null : component.HtmlHelper.FormatValue(value, format));
            return tag;
        }
    }
}
