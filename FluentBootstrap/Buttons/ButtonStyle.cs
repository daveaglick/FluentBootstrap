using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    // Keep in the root namespace to match the extensions
    public enum ButtonStyle
    {
        [Description(Css.BtnDefault)]
        Default,
        [Description(Css.BtnPrimary)]
        Primary,
        [Description(Css.BtnSuccess)]
        Success,
        [Description(Css.BtnInfo)]
        Info,
        [Description(Css.BtnWarning)]
        Warning,
        [Description(Css.BtnDanger)]
        Danger,
        [Description(Css.BtnLink)]
        Link
    }
}
