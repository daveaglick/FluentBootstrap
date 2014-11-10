using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public enum WellSize
    {
        [Description()]
        Default,
        [Description(Css.WellLg)]
        Lg,
        [Description(Css.WellSm)]
        Sm
    }
}
