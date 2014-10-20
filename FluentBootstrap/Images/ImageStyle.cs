using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public enum ImageStyle
    {
        [Description()]
        Default,
        [Description(Css.ImgRounded)]
        Rounded,
        [Description(Css.ImgCircle)]
        Circle,
        [Description(Css.ImgThumbnail)]
        Thumbnail
    }
}
