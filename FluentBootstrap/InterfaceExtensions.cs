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
        public static TComponent Disabled<TComponent>(this TComponent component, bool disabled = true)
            where TComponent : Tag, IDisabledAttribute
        {
            component.MergeAttribute("disabled", disabled ? "disabled" : null);
            return component;
        }

        public static TComponent Text<TComponent>(this TComponent component, string text)
            where TComponent : Tag, ITextAttribute
        {
            component.TextContent = text;
            return component;
        }

        public static TComponent Value<TComponent>(this TComponent component, object value, string format = null)
            where TComponent : Tag, IValueAttribute
        {
            component.MergeAttribute("value", value == null ? null : component.HtmlHelper.FormatValue(value, format));
            return component;
        }
    }
}
