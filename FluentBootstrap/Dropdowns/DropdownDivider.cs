using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Dropdowns
{
    public interface IDropdownDividerCreator<TModel> : ITagCreator<TModel>
    {
    }

    public class DropdownDividerWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface IDropdownDivider : ITag
    {
    }

    public class DropdownDivider<TModel> : Tag<TModel, DropdownDivider<TModel>, DropdownDividerWrapper<TModel>>, IDropdownDivider
    {
        internal DropdownDivider(IComponentCreator<TModel> creator)
            : base(creator, "li", Css.Divider)
        {
            MergeAttribute("role", "presentation");
        }
    }
}
