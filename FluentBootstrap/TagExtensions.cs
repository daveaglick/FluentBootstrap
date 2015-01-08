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
        public static ComponentBuilder<THelper, TTag> AddCss<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, params string[] cssClasses)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag
        {
            builder.Component.AddCss(cssClasses);
            return builder;
        }

        public static ComponentBuilder<THelper, TTag> RemoveCss<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, params string[] cssClasses)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag
        {
            builder.Component.RemoveCss(cssClasses);
            return builder;
        }

        public static ComponentBuilder<THelper, TTag> AddAttributes<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, object htmlAttributes)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag
        {
            builder.Component.MergeAttributes(htmlAttributes);
            return builder;
        }

        public static ComponentBuilder<THelper, TTag> AddAttributes<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, IDictionary<string, object> htmlAttributes)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag
        {
            builder.Component.MergeAttributes(htmlAttributes);
            return builder;
        }

        public static ComponentBuilder<THelper, TTag> AddAttribute<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, string attributeName, object value)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag
        {
            builder.Component.MergeAttribute(attributeName, Convert.ToString(value, CultureInfo.InvariantCulture));
            return builder;
        }

        public static ComponentBuilder<THelper, TTag> AddStyles<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, object inlineStyles)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag
        {
            builder.Component.MergeStyles(inlineStyles);
            return builder;
        }

        public static ComponentBuilder<THelper, TTag> AddStyles<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, IDictionary<string, object> inlineStyles)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag
        {
            builder.Component.MergeStyles(inlineStyles);
            return builder;
        }

        public static ComponentBuilder<THelper, TTag> AddStyle<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, string inlineStyle, object value)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag
        {
            builder.Component.MergeStyle(inlineStyle, Convert.ToString(value, CultureInfo.InvariantCulture));
            return builder;
        }

        public static ComponentBuilder<THelper, TTag> SetId<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, string id)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag
        {
            builder.Component.MergeAttribute("id", id);
            return builder;
        }

        public static ComponentBuilder<THelper, TTag> AddContent<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, object content)
            where THelper : BootstrapHelper<THelper>
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

        public static ComponentBuilder<THelper, TTag> AddChild<THelper, TTag, TChild>(this ComponentBuilder<THelper, TTag> builder, Func<ComponentWrapper<THelper, TTag>, ComponentBuilder<THelper, TChild>> childFunc)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag
            where TChild : Component
        {
            builder.Component.AddChild(childFunc(builder.GetWrapper()).Component);
            return builder;
        }

        // This is a very special extension - it allows adding a child using fluent style and switches the current chaining object to the child
        // behind the scenes the parent start is immediately output and the child ends the parent when it ends (so that the while hierarchy gets output)
        public static ComponentWrapper<THelper, TTag> WithChild<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag
        {
            ComponentWrapper<THelper, TTag> wrapper = builder.Begin();
            wrapper.WithChild = true;
            return wrapper;
        }

        public static ComponentBuilder<THelper, TTag> SetVisibility<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, Visibility visibility)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag
        {
            builder.Component.ToggleCss(visibility);
            return builder;
        }

        public static ComponentBuilder<THelper, TTag> SetState<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, TextState state)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag
        {
            builder.Component.ToggleCss(state);
            return builder;
        }

        public static ComponentBuilder<THelper, TTag> SetBackgroundState<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, BackgroundState backgroundState)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag
        {
            builder.Component.ToggleCss(backgroundState);
            return builder;
        }
    }
}
