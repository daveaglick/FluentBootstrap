using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FluentBootstrap
{
    public static class TagExtensions
    {
        public static ComponentBuilder<TTag> AddCss<TTag>(this ComponentBuilder<TTag> builder, params string[] cssClasses)
            where TTag : Tag
        {
            builder.Component.AddCss(cssClasses);
            return builder;
        }

        public static ComponentBuilder<TTag> RemoveCss<TTag>(this ComponentBuilder<TTag> builder, params string[] cssClasses)
            where TTag : Tag
        {
            builder.Component.RemoveCss(cssClasses);
            return builder;
        }

        public static ComponentBuilder<TTag> AddAttributes<TTag>(this ComponentBuilder<TTag> builder, object htmlAttributes)
            where TTag : Tag
        {
            builder.Component.MergeAttributes(htmlAttributes);
            return builder;
        }

        public static ComponentBuilder<TTag> AddAttributes<TTag>(this ComponentBuilder<TTag> builder, IDictionary<string, object> htmlAttributes)
            where TTag : Tag
        {
            builder.Component.MergeAttributes(htmlAttributes);
            return builder;
        }

        public static ComponentBuilder<TTag> AddAttribute<TTag>(this ComponentBuilder<TTag> builder, string attributeName, object value)
            where TTag : Tag
        {
            builder.Component.MergeAttribute(attributeName, Convert.ToString(value, CultureInfo.InvariantCulture));
            return builder;
        }

        public static ComponentBuilder<TTag> AddStyles<TTag>(this ComponentBuilder<TTag> builder, object inlineStyles)
            where TTag : Tag
        {
            builder.Component.MergeStyles(inlineStyles);
            return builder;
        }

        public static ComponentBuilder<TTag> AddStyles<TTag>(this ComponentBuilder<TTag> builder, IDictionary<string, object> inlineStyles)
            where TTag : Tag
        {
            builder.Component.MergeStyles(inlineStyles);
            return builder;
        }

        public static ComponentBuilder<TTag> AddStyle<TTag>(this ComponentBuilder<TTag> builder, string inlineStyle, object value)
            where TTag : Tag
        {
            builder.Component.MergeStyle(inlineStyle, Convert.ToString(value, CultureInfo.InvariantCulture));
            return builder;
        }

        public static ComponentBuilder<TTag> SetId<TTag>(this ComponentBuilder<TTag> builder, string id)
            where TTag : Tag
        {
            builder.Component.MergeAttribute("id", id);
            return builder;
        }

        public static ComponentBuilder<TTag> AddContent<TTag>(this ComponentBuilder<TTag> builder, object content)
            where TTag : Tag
        {
            if (content != null)
            {
                // Make sure that this isn't a component
                ComponentBuilder contentBuilder = content as ComponentBuilder;
                if (contentBuilder != null)
                {
                    builder.Component.AddChild(contentBuilder.GetComponent());
                }

                // Now check if it's an IHtmlString
                string str;
                IHtmlString htmlString = content as IHtmlString;
                if (htmlString != null)
                {
                    str = htmlString.ToHtmlString();
                }
                else
                {
                    // Just convert to a string using the standard conversion logic
                    str = Convert.ToString(content, CultureInfo.InvariantCulture);
                }

                if (!string.IsNullOrEmpty(str))
                {
                    builder.Component.AddChild(new Content(builder.GetWrapper(), str));
                }
            }
            return builder;
        }

        public static ComponentBuilder<TTag> AddChild<TTag, TChild>(this ComponentBuilder<TTag> builder, Func<ComponentWrapper<TTag>, ComponentBuilder<TChild>> childFunc)
            where TTag : Tag
            where TChild : Component
        {
            builder.Component.AddChild(childFunc(builder.GetWrapper()).Component);
            return builder;
        }

        // This is a very special extension - it allows adding a child using fluent style and switches the current chaining object to the child
        // behind the scenes the parent start is immediately output and the child ends the parent when it ends (so that the while hierarchy gets output)
        public static ComponentWrapper<TTag> WithChild<TTag>(this ComponentBuilder<TTag> builder)
            where TTag : Tag
        {
            ComponentWrapper<TTag> wrapper = builder.Begin();
            wrapper.WithChild = true;
            return wrapper;
        }

        public static ComponentBuilder<TTag> SetVisibility<TTag>(this ComponentBuilder<TTag> builder, Visibility visibility)
            where TTag : Tag
        {
            builder.Component.ToggleCss(visibility);
            return builder;
        }

        public static ComponentBuilder<TTag> SetState<TTag>(this ComponentBuilder<TTag> builder, TextState state)
            where TTag : Tag
        {
            builder.Component.ToggleCss(state);
            return builder;
        }

        public static ComponentBuilder<TTag> SetBackgroundState<TTag>(this ComponentBuilder<TTag> builder, BackgroundState backgroundState)
            where TTag : Tag
        {
            builder.Component.ToggleCss(backgroundState);
            return builder;
        }
    }
}
