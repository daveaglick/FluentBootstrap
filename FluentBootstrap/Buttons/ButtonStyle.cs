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
        [Description("btn-default")]
        Default,
        [Description("btn-primary")]
        Primary,
        [Description("btn-success")]
        Success,
        [Description("btn-info")]
        Info,
        [Description("btn-warning")]
        Warning,
        [Description("btn-danger")]
        Danger,
        [Description("btn-link")]
        Link
    }
}
