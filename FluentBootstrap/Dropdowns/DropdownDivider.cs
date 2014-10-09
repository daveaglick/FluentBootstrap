using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Dropdowns
{
    internal interface IDropdownDivider : ITag
    {
    }

    public class DropdownDivider<TModel> : Tag<TModel, DropdownDivider<TModel>>, IDropdownDivider
    {
        internal DropdownDivider(BootstrapHelper<TModel> helper)
            : base(helper, "li", Css.Divider)
        {
            MergeAttribute("role", "presentation");
        }
    }
}
