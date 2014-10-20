using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public enum InputGroupSize
    {
        [Description()]
        Default,
        [Description(Css.InputGroupLg)]
        Lg,
        [Description(Css.InputGroupSm)]
        Sm
    }
}
