using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface IListCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class ListWrapper<THelper> : TagWrapper<THelper>, IListItemCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IList : ITag
    {
    }

    public class List<THelper> : Tag<THelper, List<THelper>, ListWrapper<THelper>>, IList
        where THelper : BootstrapHelper<THelper>
    {
        internal List(IComponentCreator<THelper> creator, ListType listType)
            : base(creator, listType == ListType.Ordered ? "ol" : "ul", 
                listType == ListType.Unstyled ? Css.ListUnstyled : null,
                listType == ListType.Inline ? Css.ListInline : null)
        {
        }
    }
}
