using FluentBootstrap.MediaObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class MediaObjectExtensions
    {
        // Media

        public static ComponentBuilder<TConfig, Media> Media<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Media>
        {
            return new ComponentBuilder<TConfig, Media>(helper.Config, new Media(helper));
        }

        // Media Object

        public static ComponentBuilder<TConfig, MediaObject> MediaObject<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string src, string href = null, string alt = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<MediaObject>
        {
            return new ComponentBuilder<TConfig, MediaObject>(helper.Config, new MediaObject(helper))
                .SetHref(href)
                .SetSrc(src)
                .SetAlt(alt);
        }

        public static ComponentBuilder<TConfig, MediaObject> SetSrc<TConfig>(this ComponentBuilder<TConfig, MediaObject> builder, string src)
            where TConfig : BootstrapConfig
        {
            builder.Component.Src = src;
            return builder;
        }

        public static ComponentBuilder<TConfig, MediaObject> SetAlt<TConfig>(this ComponentBuilder<TConfig, MediaObject> builder, string alt)
            where TConfig : BootstrapConfig
        {
            builder.Component.Alt = alt;
            return builder;
        }

        public static ComponentBuilder<TConfig, MediaObject> SetLeft<TConfig>(this ComponentBuilder<TConfig, MediaObject> builder, bool left = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.ToggleCss(Css.MediaLeft, left, Css.MediaRight);
            return builder;
        }

        public static ComponentBuilder<TConfig, MediaObject> SetRight<TConfig>(this ComponentBuilder<TConfig, MediaObject> builder, bool right = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.ToggleCss(Css.MediaRight, right, Css.MediaLeft);
            return builder;
        }

        public static ComponentBuilder<TConfig, MediaObject> SetMiddle<TConfig>(this ComponentBuilder<TConfig, MediaObject> builder, bool middle = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.ToggleCss(Css.MediaMiddle, middle, Css.MediaBottom);
            return builder;
        }

        public static ComponentBuilder<TConfig, MediaObject> SetBottom<TConfig>(this ComponentBuilder<TConfig, MediaObject> builder, bool bottom = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.ToggleCss(Css.MediaBottom, bottom, Css.MediaMiddle);
            return builder;
        }

        // Media Body

        public static ComponentBuilder<TConfig, MediaBody> MediaBody<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, string heading = null, string text = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<MediaBody>
        {
            return new ComponentBuilder<TConfig, MediaBody>(helper.Config, new MediaBody(helper))
                .SetHeading(heading)
                .SetText(text);
        }

        public static ComponentBuilder<TConfig, MediaBody> SetHeading<TConfig>(this ComponentBuilder<TConfig, MediaBody> builder, string heading)
            where TConfig : BootstrapConfig
        {
            builder.Component.Heading = heading;
            return builder;
        }

        // Media List

        public static ComponentBuilder<TConfig, MediaList> MediaList<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<MediaList>
        {
            return new ComponentBuilder<TConfig, MediaList>(helper.Config, new MediaList(helper));
        }

    }
}
