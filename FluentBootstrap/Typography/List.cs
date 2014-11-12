using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface IListCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class ListWrapper<THelper> : TagWrapper<THelper>, IListItemCreator<THelper>
    {
    }

    internal interface IList : ITag
    {
    }

    public class List<THelper> : Tag<THelper, List<THelper>, ListWrapper<THelper>>, IList
    {
        internal List(IComponentCreator<THelper> creator, ListType listType)
            : base(creator, listType == ListType.Ordered ? "ol" : "ul", 
                listType == ListType.Unstyled ? Css.ListUnstyled : null,
                listType == ListType.Inline ? Css.ListInline : null)
        {
        }
    }
}
