using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public enum ButtonGroupSize
    {
        [Description()]
        Default,
        [Description(Css.BtnGroupLg)]
        Lg,
        [Description(Css.BtnGroupSm)]
        Sm,
        [Description(Css.BtnGroupXs)]
        Xs
    }
}
