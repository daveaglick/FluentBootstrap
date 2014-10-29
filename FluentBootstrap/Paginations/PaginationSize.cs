using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public enum PaginationSize
    {
        [Description()]
        Default,
        [Description(Css.PaginationLg)]
        Lg,
        [Description(Css.PaginationSm)]
        Sm
    }
}
