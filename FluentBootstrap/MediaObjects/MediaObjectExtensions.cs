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

        public static Media<TModel> Media<TModel>(this IMediaCreator<TModel> creator)
        {
            return new Media<TModel>(creator);
        }

        // Media Object

        public static MediaObject<TModel> MediaObject<TModel>(this IMediaObjectCreator<TModel> creator, string src, string href = null, string alt = null)
        {
            return new MediaObject<TModel>(creator).SetHref(href).SetSrc(src).SetAlt(alt);
        }

        public static MediaObject<TModel> MediaObject<TModel>(this IMediaObjectCreator<TModel> creator, string src, string actionName, string controllerName, object routeValues = null, string alt = null)
        {
            return new MediaObject<TModel>(creator).SetAction(actionName, controllerName, routeValues).SetSrc(src).SetAlt(alt);
        }

        public static MediaObject<TModel> SetSrc<TModel>(this MediaObject<TModel> mediaObject, string src)
        {
            mediaObject.Src = src;
            return mediaObject;
        }

        public static MediaObject<TModel> SetAlt<TModel>(this MediaObject<TModel> mediaObject, string alt)
        {
            mediaObject.Alt = alt;
            return mediaObject;
        }

        public static MediaObject<TModel> SetLeft<TModel>(this MediaObject<TModel> mediaObject, bool left = true)
        {
            return mediaObject.ToggleCss(Css.PullLeft, left, Css.PullRight);
        }

        public static MediaObject<TModel> SetRight<TModel>(this MediaObject<TModel> mediaObject, bool right = true)
        {
            return mediaObject.ToggleCss(Css.PullRight, right, Css.PullLeft);
        }

        // Media Body

        public static MediaBody<TModel> MediaBody<TModel>(this IMediaBodyCreator<TModel> creator, string heading = null, string text = null)
        {
            return new MediaBody<TModel>(creator).SetHeading(heading).SetText(text);
        }

        public static MediaBody<TModel> SetHeading<TModel>(this MediaBody<TModel> mediaBody, string heading)
        {
            mediaBody.Heading = heading;
            return mediaBody;
        }

        // Media List

        public static MediaList<TModel> MediaList<TModel>(this IMediaListCreator<TModel> creator)
        {
            return new MediaList<TModel>(creator);
        }

    }
}
