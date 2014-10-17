using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public enum TextTransformation
    {
        [Description()]
        None,
        [Description(Css.TextLowercase)]
        Lowercase,
        [Description(Css.TextUppercase)]
        Uppercase,
        [Description(Css.TextCapitalize)]
        Capitalize
    }
}
