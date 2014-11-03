using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Dropdowns
{
    public interface IDropdownHeaderCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class DropdownHeaderWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface IDropdownHeader : ITag
    {
    }

    public class DropdownHeader<TModel> : Tag<TModel, DropdownHeader<TModel>, DropdownHeaderWrapper<TModel>>, IDropdownHeader, IHasTextContent
    {
        internal DropdownHeader(IComponentCreator<TModel> creator)
            : base(creator, "li", Css.DropdownHeader)
        {
            MergeAttribute("role", "presentation");
        }
    }
}
