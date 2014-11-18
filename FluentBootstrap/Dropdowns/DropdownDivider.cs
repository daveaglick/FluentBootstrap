using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Dropdowns
{
    public interface IDropdownDividerCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class DropdownDividerWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IDropdownDivider : ITag
    {
    }

    public class DropdownDivider<THelper> : Tag<THelper, DropdownDivider<THelper>, DropdownDividerWrapper<THelper>>, IDropdownDivider
        where THelper : BootstrapHelper<THelper>
    {
        internal DropdownDivider(IComponentCreator<THelper> creator)
            : base(creator, "li", Css.Divider)
        {
            MergeAttribute("role", "presentation");
        }
    }
}
