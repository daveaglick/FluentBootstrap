using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public enum ListGroupItemState
    {
        [Description()]
        Default,
        [Description(Css.ListGroupItemSuccess)]
        Success,
        [Description(Css.ListGroupItemInfo)]
        Info,
        [Description(Css.ListGroupItemWarning)]
        Warning,
        [Description(Css.ListGroupItemDanger)]
        Danger
    }
}
