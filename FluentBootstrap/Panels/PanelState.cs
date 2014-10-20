using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public enum PanelState
    {
        [Description(Css.PanelDefault)]
        Default,
        [Description(Css.PanelPrimary)]
        Primary,
        [Description(Css.PanelSuccess)]
        Success,
        [Description(Css.PanelInfo)]
        Info,
        [Description(Css.PanelWarning)]
        Warning,
        [Description(Css.PanelDanger)]
        Danger
    }
}
