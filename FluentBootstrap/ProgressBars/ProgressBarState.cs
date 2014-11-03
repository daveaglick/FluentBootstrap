using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public enum ProgressBarState
    {
        [Description()]
        None,
        [Description(Css.ProgressBarSuccess)]
        Success,
        [Description(Css.ProgressBarInfo)]
        Info,
        [Description(Css.ProgressBarWarning)]
        Warning,
        [Description(Css.ProgressBarDanger)]
        Danger
    }
}
