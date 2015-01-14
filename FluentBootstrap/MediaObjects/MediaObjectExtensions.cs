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

        public static Media<TConfig> Media<TConfig>(this IMediaCreator<TConfig> creator)
            where TConfig : BootstrapConfig
        {
            return new Media<TConfig>(creator);
        }

        // Media Object

        public static MediaObject<TConfig> MediaObject<TConfig>(this IMediaObjectCreator<TConfig> creator, string src, string href = null, string alt = null)
            where TConfig : BootstrapConfig
        {
            return new MediaObject<TConfig>(creator).SetHref(href).SetSrc(src).SetAlt(alt);
        }

        public static MediaObject<TConfig> SetSrc<TConfig>(this MediaObject<TConfig> mediaObject, string src)
            where TConfig : BootstrapConfig
        {
            mediaObject.Src = src;
            return mediaObject;
        }

        public static MediaObject<TConfig> SetAlt<TConfig>(this MediaObject<TConfig> mediaObject, string alt)
            where TConfig : BootstrapConfig
        {
            mediaObject.Alt = alt;
            return mediaObject;
        }

        public static MediaObject<TConfig> SetLeft<TConfig>(this MediaObject<TConfig> mediaObject, bool left = true)
            where TConfig : BootstrapConfig
        {
            return mediaObject.ToggleCss(Css.MediaLeft, left, Css.MediaRight);
        }

        public static MediaObject<TConfig> SetRight<TConfig>(this MediaObject<TConfig> mediaObject, bool right = true)
            where TConfig : BootstrapConfig
        {
            return mediaObject.ToggleCss(Css.MediaRight, right, Css.MediaLeft);
        }

        // Media Body

        public static MediaBody<TConfig> MediaBody<TConfig>(this IMediaBodyCreator<TConfig> creator, string heading = null, string text = null)
            where TConfig : BootstrapConfig
        {
            return new MediaBody<TConfig>(creator).SetHeading(heading).SetText(text);
        }

        public static MediaBody<TConfig> SetHeading<TConfig>(this MediaBody<TConfig> mediaBody, string heading)
            where TConfig : BootstrapConfig
        {
            mediaBody.Heading = heading;
            return mediaBody;
        }

        // Media List

        public static MediaList<TConfig> MediaList<TConfig>(this IMediaListCreator<TConfig> creator)
            where TConfig : BootstrapConfig
        {
            return new MediaList<TConfig>(creator);
        }

    }
}
