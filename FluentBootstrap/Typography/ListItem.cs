using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface IListItem : ITag
    {
    }

    public interface IListItemCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class ListItem<TModel> : Tag<TModel, ListItem<TModel>>, IListItem
    {

        internal ListItem(BootstrapHelper<TModel> helper)
            : base(helper, "li")
        {
        }
    }
}
