using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Dropdowns
{
    public interface IDropdownHeaderCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class DropdownHeaderWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IDropdownHeader : ITag
    {
    }

    public class DropdownHeader<THelper> : Tag<THelper, DropdownHeader<THelper>, DropdownHeaderWrapper<THelper>>, IDropdownHeader, IHasTextContent
        where THelper : BootstrapHelper<THelper>
    {
        internal DropdownHeader(IComponentCreator<THelper> creator)
            : base(creator, "li", Css.DropdownHeader)
        {
            MergeAttribute("role", "presentation");
        }
    }
}
