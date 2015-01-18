using FluentBootstrap.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class ImageExtensions
    {
        // Image

        public static ComponentBuilder<TConfig, Image> Image<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string src, string alt = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Image>
        {
            return new ComponentBuilder<TConfig, Image>(helper.Config, new Image(helper))
                .SetSrc(src)
                .SetAlt(alt);
        }

        public static ComponentBuilder<TConfig, Image> SetSrc<TConfig>(this ComponentBuilder<TConfig, Image> builder, string src)
            where TConfig : BootstrapConfig
        {
            builder.Component.MergeAttribute("src", src);
            return builder;
        }

        // Placeholder

        public static ComponentBuilder<TConfig, Placeholder> Placeholder<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, int width, int? height = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Placeholder>
        {
            return new ComponentBuilder<TConfig, Placeholder>(helper.Config, new Placeholder(helper, width, height));
        }        

        public static ComponentBuilder<TConfig, Placeholder> SetWidth<TConfig>(this ComponentBuilder<TConfig, Placeholder> builder, int width)
            where TConfig : BootstrapConfig
        {
            builder.Component.Width = width;
            return builder;
        }

        public static ComponentBuilder<TConfig, Placeholder> SetHeight<TConfig>(this ComponentBuilder<TConfig, Placeholder> builder, int height)
            where TConfig : BootstrapConfig
        {
            builder.Component.Height = height;
            return builder;
        }

        public static ComponentBuilder<TConfig, Placeholder> SetText<TConfig>(this ComponentBuilder<TConfig, Placeholder> builder, string text)
            where TConfig : BootstrapConfig
        {
            builder.Component.Text = text;
            return builder;
        }

        public static ComponentBuilder<TConfig, Placeholder> SetFormat<TConfig>(this ComponentBuilder<TConfig, Placeholder> builder, string format)
            where TConfig : BootstrapConfig
        {
            builder.Component.Format = format;
            return builder;
        }

        public static ComponentBuilder<TConfig, Placeholder> SetColors<TConfig>(this ComponentBuilder<TConfig, Placeholder> builder, string backgroundColor, string textColor)
            where TConfig : BootstrapConfig
        {
            builder.Component.BackgroundColor = backgroundColor;
            builder.Component.TextColor = textColor;
            return builder;
        }

        // ImageBase

        public static ComponentBuilder<TConfig, TImage> SetAlt<TConfig, TImage>(this ComponentBuilder<TConfig, TImage> builder, string alt)
            where TConfig : BootstrapConfig
            where TImage : ImageBase
        {
            builder.Component.MergeAttribute("alt", alt);
            return builder;
        }

        public static ComponentBuilder<TConfig, TImage> SetResponsive<TConfig, TImage>(this ComponentBuilder<TConfig, TImage> builder, bool responsive = true)
            where TConfig : BootstrapConfig
            where TImage : ImageBase
        {
            builder.Component.ToggleCss(Css.ImgResponsive, responsive);
            return builder;
        }

        public static ComponentBuilder<TConfig, TImage> SetStyle<TConfig, TImage>(this ComponentBuilder<TConfig, TImage> builder, ImageStyle style)
            where TConfig : BootstrapConfig
            where TImage : ImageBase
        {
            builder.Component.ToggleCss(style);
            return builder;
        }
    }
}
