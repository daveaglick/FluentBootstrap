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

        public static Thumbnail<TModel> Thumbnail<TModel>(this IThumbnailCreator<TModel> creator, string src, string href = null, string alt = null)
        {
            return new Thumbnail<TModel>(creator).SetHref(href).SetSrc(src).SetAlt(alt);
        }

        public static Thumbnail<TModel> Thumbnail<TModel>(this IThumbnailCreator<TModel> creator, string src, string actionName, string controllerName, object routeValues = null, string alt = null)
        {
            return new Thumbnail<TModel>(creator).SetAction(actionName, controllerName, routeValues).SetSrc(src).SetAlt(alt);
        }

        public static Thumbnail<TModel> SetSrc<TModel>(this Thumbnail<TModel> thumbnail, string src)
        {
            thumbnail.Src = src;
            return thumbnail;
        }

        public static Thumbnail<TModel> SetAlt<TModel>(this Thumbnail<TModel> thumbnail, string alt)
        {
            thumbnail.Alt = alt;
            return thumbnail;
        }

        // ThumbnailContainer

        public static ThumbnailContainer<TModel> ThumbnailContainer<TModel>(this IThumbnailContainerCreator<TModel> creator)
        {
            return new ThumbnailContainer<TModel>(creator);
        }

        public static Caption<TModel> Caption<TModel>(this ICaptionCreator<TModel> creator)
        {
            return new Caption<TModel>(creator);
        }
    }
}
