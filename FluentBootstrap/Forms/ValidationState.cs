using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public enum ValidationState
    {
        [Description()]
        Default,
        [Description(Css.HasSuccess)]
        Success,
        [Description(Css.HasWarning)]
        Warning,
        [Description(Css.HasError)]
        Error
    }
}
