using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    // Keep in the root namespace to match the extensions
    public enum ButtonType
    {
        [Description("button")]
        Button,
        [Description("reset")]
        Reset,
        [Description("submit")]
        Submit
    }
}
