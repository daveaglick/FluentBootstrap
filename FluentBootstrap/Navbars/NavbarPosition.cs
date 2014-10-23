using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public enum NavbarPosition
    {
        [Description()]
        Default,
        [Description(Css.NavbarFixedTop)]
        FixedTop,
        [Description(Css.NavbarFixedBottom)]
        FixedBottm,
        [Description(Css.NavbarStaticTop)]
        StaticTop
    }
}
