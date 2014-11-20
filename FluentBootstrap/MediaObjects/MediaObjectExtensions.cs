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

        public static Media<THelper> Media<THelper>(this IMediaCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new Media<THelper>(creator);
        }

        // Media Object

        public static MediaObject<THelper> MediaObject<THelper>(this IMediaObjectCreator<THelper> creator, string src, string href = null, string alt = null)
            where THelper : BootstrapHelper<THelper>
        {
            return new MediaObject<THelper>(creator).SetHref(href).SetSrc(src).SetAlt(alt);
        }

        public static MediaObject<THelper> SetSrc<THelper>(this MediaObject<THelper> mediaObject, string src)
            where THelper : BootstrapHelper<THelper>
        {
            mediaObject.Src = src;
            return mediaObject;
        }

        public static MediaObject<THelper> SetAlt<THelper>(this MediaObject<THelper> mediaObject, string alt)
            where THelper : BootstrapHelper<THelper>
        {
            mediaObject.Alt = alt;
            return mediaObject;
        }

        public static MediaObject<THelper> SetLeft<THelper>(this MediaObject<THelper> mediaObject, bool left = true)
            where THelper : BootstrapHelper<THelper>
        {
            return mediaObject.ToggleCss(Css.MediaLeft, left, Css.MediaRight);
        }

        public static MediaObject<THelper> SetRight<THelper>(this MediaObject<THelper> mediaObject, bool right = true)
            where THelper : BootstrapHelper<THelper>
        {
            return mediaObject.ToggleCss(Css.MediaRight, right, Css.MediaLeft);
        }

        // Media Body

        public static MediaBody<THelper> MediaBody<THelper>(this IMediaBodyCreator<THelper> creator, string heading = null, string text = null)
            where THelper : BootstrapHelper<THelper>
        {
            return new MediaBody<THelper>(creator).SetHeading(heading).SetText(text);
        }

        public static MediaBody<THelper> SetHeading<THelper>(this MediaBody<THelper> mediaBody, string heading)
            where THelper : BootstrapHelper<THelper>
        {
            mediaBody.Heading = heading;
            return mediaBody;
        }

        // Media List

        public static MediaList<THelper> MediaList<THelper>(this IMediaListCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new MediaList<THelper>(creator);
        }

    }
}
