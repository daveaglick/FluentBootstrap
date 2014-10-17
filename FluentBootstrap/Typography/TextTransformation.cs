using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public enum TextTransformation
    {
        [Description(Css.TextLowercase)]
        Lowercase,
        [Description(Css.TextUppercase)]
        Uppercase,
        [Description(Css.TextCapitalize)]
        Capitalize
    }
}
