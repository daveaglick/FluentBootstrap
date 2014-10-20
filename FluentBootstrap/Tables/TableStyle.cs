using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    [Flags]
    public enum TableStyle
    {
        [Description(Css.TableStriped)]
        Striped = 1,
        [Description(Css.TableBordered)]
        Bordered = 1 << 1,
        [Description(Css.TableHover)]
        Hover = 1 << 2,
        [Description(Css.TableCondensed)]
        Condensed = 1 << 3
    }
}
