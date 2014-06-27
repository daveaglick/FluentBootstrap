using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    internal interface IList : ITag
    {
    }

    public interface IListCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class List<TModel> : Tag<TModel, List<TModel>>, IList,
        IListItemCreator<TModel>
    {

        internal List(BootstrapHelper<TModel> helper, ListType listType)
            : base(helper, listType == ListType.Ordered ? "ol" : "ul", 
                listType == ListType.Unstyled ? "list-unstyled" : null,
                listType == ListType.Inline ? "list-inline" : null)
        {
        }
    }
}
