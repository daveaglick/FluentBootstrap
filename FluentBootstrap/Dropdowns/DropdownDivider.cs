using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Dropdowns
{
    public interface IDropdownDividerCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class DropdownDividerWrapper<THelper> : TagWrapper<THelper>
    {
    }

    internal interface IDropdownDivider : ITag
    {
    }

    public class DropdownDivider<THelper> : Tag<THelper, DropdownDivider<THelper>, DropdownDividerWrapper<THelper>>, IDropdownDivider
    {
        internal DropdownDivider(IComponentCreator<THelper> creator)
            : base(creator, "li", Css.Divider)
        {
            MergeAttribute("role", "presentation");
        }
    }
}
