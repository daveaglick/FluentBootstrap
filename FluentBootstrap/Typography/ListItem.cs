using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface IListItemCreator<TModel> : ITagCreator<TModel>
    {
    }

    public class ListItemWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface IListItem : ITag
    {
    }

    public class ListItem<TModel> : Tag<TModel, ListItem<TModel>, ListItemWrapper<TModel>>, IListItem
    {
        internal ListItem(IComponentCreator<TModel> creator)
            : base(creator, "li")
        {
        }
    }
}
