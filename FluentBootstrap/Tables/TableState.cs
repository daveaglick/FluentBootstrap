using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public enum TableState
    {
        [Description()]
        Default,
        [Description(Css.Active)]
        Active,
        [Description(Css.Success)]
        Success,
        [Description(Css.Warning)]
        Warning,
        [Description(Css.Danger)]
        Danger,
        [Description(Css.Info)]
        Info
    }
}
