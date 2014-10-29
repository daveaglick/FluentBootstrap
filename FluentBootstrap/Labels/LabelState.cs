using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{

    public enum LabelState
    {
        [Description(Css.LabelDefault)]
        Default,
        [Description(Css.LabelPrimary)]
        Primary,
        [Description(Css.LabelSuccess)]
        Success,
        [Description(Css.LabelInfo)]
        Info,
        [Description(Css.LabelWarning)]
        Warning,
        [Description(Css.LabelDanger)]
        Danger
    }
}
