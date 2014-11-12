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

        public static Thumbnail<THelper> Thumbnail<THelper>(this IThumbnailCreator<THelper> creator, string src, string href = null, string alt = null)
        {
            return new Thumbnail<THelper>(creator).SetHref(href).SetSrc(src).SetAlt(alt);
        }

        public static Thumbnail<THelper> Thumbnail<THelper>(this IThumbnailCreator<THelper> creator, string src, string actionName, string controllerName, object routeValues = null, string alt = null)
        {
            return new Thumbnail<THelper>(creator).SetAction(actionName, controllerName, routeValues).SetSrc(src).SetAlt(alt);
        }

        public static Thumbnail<THelper> SetSrc<THelper>(this Thumbnail<THelper> thumbnail, string src)
        {
            thumbnail.Src = src;
            return thumbnail;
        }

        public static Thumbnail<THelper> SetAlt<THelper>(this Thumbnail<THelper> thumbnail, string alt)
        {
            thumbnail.Alt = alt;
            return thumbnail;
        }

        // ThumbnailContainer

        public static ThumbnailContainer<THelper> ThumbnailContainer<THelper>(this IThumbnailContainerCreator<THelper> creator)
        {
            return new ThumbnailContainer<THelper>(creator);
        }

        public static Caption<THelper> Caption<THelper>(this ICaptionCreator<THelper> creator)
        {
            return new Caption<THelper>(creator);
        }
    }
}
