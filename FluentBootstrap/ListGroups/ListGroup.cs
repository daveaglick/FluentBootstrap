using FluentBootstrap.Badges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.ListGroups
{
    public interface IListGroupCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class ListGroupWrapper<TModel> : TagWrapper<TModel>,
        IListGroupItemCreator<TModel>
    {
    }

    internal interface IListGroup : ITag
    {
    }

    public class ListGroup<TModel> : Tag<TModel, ListGroup<TModel>, ListGroupWrapper<TModel>>, IListGroup
    {
        internal ListGroup(IComponentCreator<TModel> creator)
            : base(creator, "div", Css.ListGroup)
        {
        }
    }
}
