using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public enum TextAlignment
    {
        [Description(Css.TextLeft)]
        Left,
        [Description(Css.TextCenter)]
        Center,
        [Description(Css.TextRight)]
        Right,
        [Description(Css.TextJustify)]
        Justify,
        [Description(Css.TextNowrap)]
        Nowrap
    }
}
