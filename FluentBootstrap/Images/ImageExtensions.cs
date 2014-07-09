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
        public static Image<TModel> Image<TModel>(this IImageCreator<TModel> creator, string src, string alt = null)
        {
            return new Image<TModel>(creator.GetHelper()).Src(src).Alt(alt);
        }

        public static Image<TModel> Src<TModel>(this Image<TModel> image, string src)
        {
            return image.MergeAttribute("src", src);
        }

        public static Image<TModel> Alt<TModel>(this Image<TModel> image, string alt)
        {
            return image.MergeAttribute("alt", alt);
        }

        public static Image<TModel> Responsive<TModel>(this Image<TModel> image, bool responsive = true)
        {
            return image.ToggleCss(Css.ImgResponsive, responsive);
        }

        public static Image<TModel> Rounded<TModel>(this Image<TModel> image, bool rounded = true)
        {
            return image.ToggleCss(Css.ImgRounded, rounded, Css.ImgCircle, Css.ImgThumbnail);
        }

        public static Image<TModel> Circle<TModel>(this Image<TModel> image, bool circle = true)
        {
            return image.ToggleCss(Css.ImgCircle, circle, Css.ImgRounded, Css.ImgThumbnail);
        }

        public static Image<TModel> Thumbnail<TModel>(this Image<TModel> image, bool thumbnail = true)
        {
            return image.ToggleCss(Css.ImgThumbnail, thumbnail, Css.ImgRounded, Css.ImgCircle);
        }
    }
}
