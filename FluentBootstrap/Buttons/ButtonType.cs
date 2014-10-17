using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
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
