using FluentBootstrap.Thumbnails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class ThumbnailExtensions
    {
        // Thumbnail

        public static ComponentBuilder<TConfig, Thumbnail> Thumbnail<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string src, string alt = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Thumbnail>
        {
            return new ComponentBuilder<TConfig, Thumbnail>(helper.Config, new Thumbnail(helper))
                .SetSrc(src)
                .SetAlt(alt);
        }

        public static ComponentBuilder<TConfig, Thumbnail> SetSrc<TConfig>(this ComponentBuilder<TConfig, Thumbnail> builder, string src)
            where TConfig : BootstrapConfig
        {
            builder.Component.Src = src;
            return builder;
        }

        public static ComponentBuilder<TConfig, Thumbnail> SetAlt<TConfig>(this ComponentBuilder<TConfig, Thumbnail> builder, string alt)
            where TConfig : BootstrapConfig
        {
            builder.Component.Alt = alt;
            return builder;
        }

        // ThumbnailContainer

        public static ComponentBuilder<TConfig, ThumbnailContainer> ThumbnailContainer<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<ThumbnailContainer>
        {
            return new ComponentBuilder<TConfig, ThumbnailContainer>(helper.Config, new ThumbnailContainer(helper));
        }

        // Caption

        public static ComponentBuilder<TConfig, Caption> Caption<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Caption>
        {
            return new ComponentBuilder<TConfig, Caption>(helper.Config, new Caption(helper));
        }
    }
}
