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

        public static ComponentBuilder<TConfig, Image> SetAlt<TConfig>(this ComponentBuilder<TConfig, Image> builder, string alt)
            where TConfig : BootstrapConfig
        {
            builder.Component.MergeAttribute("alt", alt);
            return builder;
        }

        public static ComponentBuilder<TConfig, Image> SetResponsive<TConfig>(this ComponentBuilder<TConfig, Image> builder, bool responsive = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.ToggleCss(Css.ImgResponsive, responsive);
            return builder;
        }

        public static ComponentBuilder<TConfig, Image> SetStyle<TConfig>(this ComponentBuilder<TConfig, Image> builder, ImageStyle style)
            where TConfig : BootstrapConfig
        {
            builder.Component.ToggleCss(style);
            return builder;
        }
    }
}
