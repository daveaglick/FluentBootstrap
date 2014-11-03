using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public enum AlertState
    {
        [Description(Css.AlertSuccess)]
        Success,
        [Description(Css.AlertInfo)]
        Info,
        [Description(Css.AlertWarning)]
        Warning,
        [Description(Css.AlertDanger)]
        Danger
    }
}
