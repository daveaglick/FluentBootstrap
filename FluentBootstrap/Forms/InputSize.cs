using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public enum InputSize
    {
        [Description()]
        Default,
        [Description(Css.InputLg)]
        Lg,
        [Description(Css.InputSm)]
        Sm
    }
}
