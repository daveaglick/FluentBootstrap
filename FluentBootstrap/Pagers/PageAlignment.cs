using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public enum PageAlignment
    {
        [Description()]
        Default,
        [Description(Css.Previous)]
        Previous,
        [Description(Css.Next)]
        Next
    }
}
