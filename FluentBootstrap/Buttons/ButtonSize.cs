using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public enum ButtonSize
    {
        [Description()]
        Default,
        [Description(Css.BtnLg)]
        Lg,
        [Description(Css.BtnSm)]
        Sm,
        [Description(Css.BtnXs)]
        Xs
    }
}
