using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public enum BackgroundState
    {
        [Description(Css.BgPrimary)]
        Primary,
        [Description(Css.BgSuccess)]
        Success,
        [Description(Css.BgInfo)]
        Info,
        [Description(Css.BgWarning)]
        Warning,
        [Description(Css.BgDanger)]
        Danger
    }
}
