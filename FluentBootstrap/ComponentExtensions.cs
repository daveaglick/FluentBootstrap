using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages;

namespace FluentBootstrap
{
    public static class ComponentExtensions
    {
        public static TComponent CssClass<TComponent>(this TComponent component, params string[] cssClasses)
            where TComponent : BootstrapComponent
        {
            foreach (string cssClass in cssClasses)
            {
                component.CssClasses.Add(cssClass);
            }
            return component;
        }

        public static TComponent HtmlAttributes<TComponent>(this TComponent component, object htmlAttributes)
            where TComponent : BootstrapComponent
        {
            component.MergeAttributes(htmlAttributes);
            return component;
        }

        public static TComponent HtmlAttributes<TComponent>(this TComponent component, IDictionary<string, object> htmlAttributes)
            where TComponent : BootstrapComponent
        {
            component.MergeAttributes(htmlAttributes);
            return component;
        }

        public static TComponent HtmlAttribute<TComponent>(this TComponent component, string key, object value)
            where TComponent : BootstrapComponent
        {
            component.MergeAttribute(key, Convert.ToString(value, CultureInfo.InvariantCulture));
            return component;
        }

        public static TComponent Content<TComponent>(this TComponent component, object content)
            where TComponent : BootstrapComponent
        {
            component.AppendContent(
                Convert.ToString(content, CultureInfo.InvariantCulture));
            return component;
        }
        
        public static TComponent Content<TComponent>(this TComponent component, Func<dynamic, HelperResult> content)
            where TComponent : BootstrapComponent
        {
            component.AppendContent(content(null).ToHtmlString());
            return component;
        }

        public static TComponent Child<TComponent, TChild>(this TComponent component, Func<BootstrapHelper, TChild> childFunc)
            where TComponent : BootstrapComponent
            where TChild : BootstrapComponent
        {
            TChild child = childFunc(component.Helper);
            component.AddChild(child);
            return component;
        }
    }
}
