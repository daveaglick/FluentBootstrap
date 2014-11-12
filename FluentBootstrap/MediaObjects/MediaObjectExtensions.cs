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
        {
            return new Media<THelper>(creator);
        }

        // Media Object

        public static MediaObject<THelper> MediaObject<THelper>(this IMediaObjectCreator<THelper> creator, string src, string href = null, string alt = null)
        {
            return new MediaObject<THelper>(creator).SetHref(href).SetSrc(src).SetAlt(alt);
        }

        public static MediaObject<THelper> MediaObject<THelper>(this IMediaObjectCreator<THelper> creator, string src, string actionName, string controllerName, object routeValues = null, string alt = null)
        {
            return new MediaObject<THelper>(creator).SetAction(actionName, controllerName, routeValues).SetSrc(src).SetAlt(alt);
        }

        public static MediaObject<THelper> SetSrc<THelper>(this MediaObject<THelper> mediaObject, string src)
        {
            mediaObject.Src = src;
            return mediaObject;
        }

        public static MediaObject<THelper> SetAlt<THelper>(this MediaObject<THelper> mediaObject, string alt)
        {
            mediaObject.Alt = alt;
            return mediaObject;
        }

        public static MediaObject<THelper> SetLeft<THelper>(this MediaObject<THelper> mediaObject, bool left = true)
        {
            return mediaObject.ToggleCss(Css.PullLeft, left, Css.PullRight);
        }

        public static MediaObject<THelper> SetRight<THelper>(this MediaObject<THelper> mediaObject, bool right = true)
        {
            return mediaObject.ToggleCss(Css.PullRight, right, Css.PullLeft);
        }

        // Media Body

        public static MediaBody<THelper> MediaBody<THelper>(this IMediaBodyCreator<THelper> creator, string heading = null, string text = null)
        {
            return new MediaBody<THelper>(creator).SetHeading(heading).SetText(text);
        }

        public static MediaBody<THelper> SetHeading<THelper>(this MediaBody<THelper> mediaBody, string heading)
        {
            mediaBody.Heading = heading;
            return mediaBody;
        }

        // Media List

        public static MediaList<THelper> MediaList<THelper>(this IMediaListCreator<THelper> creator)
        {
            return new MediaList<THelper>(creator);
        }

    }
}
