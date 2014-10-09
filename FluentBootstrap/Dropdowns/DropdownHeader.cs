using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Dropdowns
{
    internal interface IDropdownHeader : ITag
    {
    }

    public class DropdownHeader<TModel> : Tag<TModel, DropdownHeader<TModel>>, IDropdownHeader, IHasTextAttribute
    {
        internal DropdownHeader(BootstrapHelper<TModel> helper)
            : base(helper, "li", Css.DropdownHeader)
        {
            MergeAttribute("role", "presentation");
        }
    }
}
