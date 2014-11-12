using FluentBootstrap.Badges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.ListGroups
{
    public interface IListGroupCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class ListGroupWrapper<THelper> : TagWrapper<THelper>,
        IListGroupItemCreator<THelper>
    {
    }

    internal interface IListGroup : ITag
    {
    }

    public class ListGroup<THelper> : Tag<THelper, ListGroup<THelper>, ListGroupWrapper<THelper>>, IListGroup
    {
        internal ListGroup(IComponentCreator<THelper> creator)
            : base(creator, "div", Css.ListGroup)
        {
        }
    }
}
