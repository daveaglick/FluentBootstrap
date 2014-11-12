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
        public static Image<THelper> Image<THelper>(this IImageCreator<THelper> creator, string src, string alt = null)
            where THelper : BootstrapHelper<THelper>
        {
            return new Image<THelper>(creator.GetHelper()).SetSrc(src).SetAlt(alt);
        }

        public static Image<THelper> SetSrc<THelper>(this Image<THelper> image, string src)
            where THelper : BootstrapHelper<THelper>
        {
            return image.MergeAttribute("src", src);
        }

        public static Image<THelper> SetAlt<THelper>(this Image<THelper> image, string alt)
            where THelper : BootstrapHelper<THelper>
        {
            return image.MergeAttribute("alt", alt);
        }

        public static Image<THelper> SetResponsive<THelper>(this Image<THelper> image, bool responsive = true)
            where THelper : BootstrapHelper<THelper>
        {
            return image.ToggleCss(Css.ImgResponsive, responsive);
        }

        public static Image<THelper> SetStyle<THelper>(this Image<THelper> image, ImageStyle style)
            where THelper : BootstrapHelper<THelper>
        {
            return image.ToggleCss(style);
        }
    }
}
