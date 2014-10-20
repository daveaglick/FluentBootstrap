using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public enum TextState
    {
        [Description()]
        Default,
        [Description(Css.TextMuted)]
        Muted,
        [Description(Css.TextPrimary)]
        Primary,
        [Description(Css.TextSuccess)]
        Success,
        [Description(Css.TextInfo)]
        Info,
        [Description(Css.TextWarning)]
        Warning,
        [Description(Css.TextDanger)]
        Danger
    }
}
