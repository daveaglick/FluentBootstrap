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
            return new Image<TModel>(creator.GetHelper()).SetSrc(src).SetAlt(alt);
        }

        public static Image<TModel> SetSrc<TModel>(this Image<TModel> image, string src)
        {
            return image.MergeAttribute("src", src);
        }

        public static Image<TModel> SetAlt<TModel>(this Image<TModel> image, string alt)
        {
            return image.MergeAttribute("alt", alt);
        }

        public static Image<TModel> SetResponsive<TModel>(this Image<TModel> image, bool responsive = true)
        {
            return image.ToggleCss(Css.ImgResponsive, responsive);
        }

        public static Image<TModel> SetStyle<TModel>(this Image<TModel> image, ImageStyle style)
        {
            return image.ToggleCss(style);
        }
    }
}
