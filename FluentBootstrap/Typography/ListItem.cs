using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface IListItemCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class ListItemWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IListItem : ITag
    {
    }

    public class ListItem<THelper> : Tag<THelper, ListItem<THelper>, ListItemWrapper<THelper>>, IListItem
        where THelper : BootstrapHelper<THelper>
    {
        internal ListItem(IComponentCreator<THelper> creator)
            : base(creator, "li")
        {
        }
    }
}
