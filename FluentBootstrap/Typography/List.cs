using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface IListCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class ListWrapper<TModel> : TagWrapper<TModel>, IListItemCreator<TModel>
    {
    }

    internal interface IList : ITag
    {
    }

    public class List<TModel> : Tag<TModel, List<TModel>, ListWrapper<TModel>>, IList
    {
        internal List(IComponentCreator<TModel> creator, ListType listType)
            : base(creator, listType == ListType.Ordered ? "ol" : "ul", 
                listType == ListType.Unstyled ? Css.ListUnstyled : null,
                listType == ListType.Inline ? Css.ListInline : null)
        {
        }
    }
}
