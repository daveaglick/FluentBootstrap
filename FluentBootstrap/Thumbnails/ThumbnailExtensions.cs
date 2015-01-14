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

        public static Thumbnail<TConfig> Thumbnail<TConfig>(this IThumbnailCreator<TConfig> creator, string src, string href = null, string alt = null)
            where TConfig : BootstrapConfig
        {
            return new Thumbnail<TConfig>(creator).SetHref(href).SetSrc(src).SetAlt(alt);
        }

        public static Thumbnail<TConfig> SetSrc<TConfig>(this Thumbnail<TConfig> thumbnail, string src)
            where TConfig : BootstrapConfig
        {
            thumbnail.Src = src;
            return thumbnail;
        }

        public static Thumbnail<TConfig> SetAlt<TConfig>(this Thumbnail<TConfig> thumbnail, string alt)
            where TConfig : BootstrapConfig
        {
            thumbnail.Alt = alt;
            return thumbnail;
        }

        // ThumbnailContainer

        public static ThumbnailContainer<TConfig> ThumbnailContainer<TConfig>(this IThumbnailContainerCreator<TConfig> creator)
            where TConfig : BootstrapConfig
        {
            return new ThumbnailContainer<TConfig>(creator);
        }

        public static Caption<TConfig> Caption<TConfig>(this ICaptionCreator<TConfig> creator)
            where TConfig : BootstrapConfig
        {
            return new Caption<TConfig>(creator);
        }
    }
}
