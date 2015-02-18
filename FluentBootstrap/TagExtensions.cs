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
        public static ComponentBuilder<TConfig, TTag> AddCss<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, params string[] cssClasses)
            where TConfig : BootstrapConfig
            where TTag : Tag
        {
            builder.Component.AddCss(cssClasses);
            return builder;
        }

        public static ComponentBuilder<TConfig, TTag> RemoveCss<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, params string[] cssClasses)
            where TConfig : BootstrapConfig 
            where TTag : Tag
        {
            builder.Component.RemoveCss(cssClasses);
            return builder;
        }

        public static ComponentBuilder<TConfig, TTag> AddAttributes<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, object htmlAttributes)
            where TConfig : BootstrapConfig 
            where TTag : Tag
        {
            builder.Component.MergeAttributes(htmlAttributes);
            return builder;
        }

        public static ComponentBuilder<TConfig, TTag> AddAttributes<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, IDictionary<string, object> htmlAttributes)
            where TConfig : BootstrapConfig 
            where TTag : Tag
        {
            builder.Component.MergeAttributes(htmlAttributes);
            return builder;
        }

        public static ComponentBuilder<TConfig, TTag> AddAttribute<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, string attributeName, object value)
            where TConfig : BootstrapConfig 
            where TTag : Tag
        {
            builder.Component.MergeAttribute(attributeName, Convert.ToString(value, CultureInfo.InvariantCulture));
            return builder;
        }

        public static ComponentBuilder<TConfig, TTag> AddStyles<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, object inlineStyles)
            where TConfig : BootstrapConfig 
            where TTag : Tag
        {
            builder.Component.MergeStyles(inlineStyles);
            return builder;
        }

        public static ComponentBuilder<TConfig, TTag> AddStyles<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, IDictionary<string, object> inlineStyles)
            where TConfig : BootstrapConfig 
            where TTag : Tag
        {
            builder.Component.MergeStyles(inlineStyles);
            return builder;
        }

        public static ComponentBuilder<TConfig, TTag> AddStyle<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, string inlineStyle, object value)
            where TConfig : BootstrapConfig 
            where TTag : Tag
        {
            builder.Component.MergeStyle(inlineStyle, Convert.ToString(value, CultureInfo.InvariantCulture));
            return builder;
        }

        public static ComponentBuilder<TConfig, TTag> SetId<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, string id)
            where TConfig : BootstrapConfig 
            where TTag : Tag
        {
            builder.Component.MergeAttribute("id", id);
            return builder;
        }

        public static ComponentBuilder<TConfig, TTag> AddContent<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, object content)
            where TConfig : BootstrapConfig 
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
                    builder.Component.AddChild(builder.GetHelper().Content(str));
                }
            }
            return builder;
        }

        public static ComponentBuilder<TConfig, TTag> AddContentAtEnd<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, object content)
            where TConfig : BootstrapConfig 
            where TTag : Tag
        {
            if (content != null)
            {
                // Make sure that this isn't a component
                ComponentBuilder contentBuilder = content as ComponentBuilder;
                if (contentBuilder != null)
                {
                    builder.Component.AddChildAtEnd(contentBuilder.GetComponent());
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
                    builder.Component.AddChildAtEnd(builder.GetHelper().Content(str));
                }
            }
            return builder;
        }

        public static ComponentBuilder<TConfig, TTag> AddChild<TConfig, TTag, TChild>(this ComponentBuilder<TConfig, TTag> builder, Func<ComponentWrapper<TConfig, TTag>, ComponentBuilder<TConfig, TChild>> childFunc)
            where TConfig : BootstrapConfig 
            where TTag : Tag
            where TChild : Component
        {
            builder.Component.AddChild(childFunc(builder.GetWrapper()).Component);
            return builder;
        }

        public static ComponentBuilder<TConfig, TTag> AddChild<TConfig, TTag, TChild>(this ComponentBuilder<TConfig, TTag> builder, ComponentBuilder<TConfig, TChild> child)
            where TConfig : BootstrapConfig 
            where TTag : Tag
            where TChild : Component
        {
            builder.Component.AddChild(child);
            return builder;
        }

        public static ComponentBuilder<TConfig, TTag> AddChildAtEnd<TConfig, TTag, TChild>(this ComponentBuilder<TConfig, TTag> builder, Func<ComponentWrapper<TConfig, TTag>, ComponentBuilder<TConfig, TChild>> childFunc)
            where TConfig : BootstrapConfig 
            where TTag : Tag
            where TChild : Component
        {
            builder.Component.AddChildAtEnd(childFunc(builder.GetWrapper()).Component);
            return builder;
        }

        public static ComponentBuilder<TConfig, TTag> AddChildAtEnd<TConfig, TTag, TChild>(this ComponentBuilder<TConfig, TTag> builder, ComponentBuilder<TConfig, TChild> child)
            where TConfig : BootstrapConfig 
            where TTag : Tag
            where TChild : Component
        {
            builder.Component.AddChildAtEnd(child);
            return builder;
        }

        // This is a very special extension - it allows adding a child using fluent style and switches the current chaining object to the child
        // behind the scenes the parent start is immediately output and the child ends the parent when it ends (so that the while hierarchy gets output)
        public static ComponentWrapper<TConfig, TTag> WithChild<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder)
            where TConfig : BootstrapConfig 
            where TTag : Tag
        {
            ComponentWrapper<TConfig, TTag> wrapper = builder.Begin();
            wrapper.WithChild = true;
            return wrapper;
        }

        public static ComponentBuilder<TConfig, TTag> SetVisibility<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, Visibility visibility)
            where TConfig : BootstrapConfig 
            where TTag : Tag
        {
            builder.Component.ToggleCss(visibility);
            return builder;
        }

        public static ComponentBuilder<TConfig, TTag> SetState<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, TextState state)
            where TConfig : BootstrapConfig 
            where TTag : Tag
        {
            builder.Component.ToggleCss(state);
            return builder;
        }

        public static ComponentBuilder<TConfig, TTag> SetBackgroundState<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, BackgroundState backgroundState)
            where TConfig : BootstrapConfig 
            where TTag : Tag
        {
            builder.Component.ToggleCss(backgroundState);
            return builder;
        }

        public static ComponentBuilder<TConfig, TTag> SetPullLeft<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, bool pullLeft = true)
            where TConfig : BootstrapConfig
            where TTag : Tag
        {
            builder.Component.ToggleCss(Css.PullLeft, pullLeft);
            return builder;
        }

        public static ComponentBuilder<TConfig, TTag> SetPullRight<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, bool pullRight = true)
            where TConfig : BootstrapConfig
            where TTag : Tag
        {
            builder.Component.ToggleCss(Css.PullRight, pullRight);
            return builder;
        }

        public static ComponentBuilder<TConfig, TTag> SetCenterBlock<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, bool centerBlock = true)
            where TConfig : BootstrapConfig
            where TTag : Tag
        {
            builder.Component.ToggleCss(Css.CenterBlock, centerBlock);
            return builder;
        }
    }
}
