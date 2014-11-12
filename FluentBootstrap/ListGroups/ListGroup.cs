using FluentBootstrap.Badges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.ListGroups
{
    public interface IListGroupCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class ListGroupWrapper<THelper> : TagWrapper<THelper>,
        IListGroupItemCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IListGroup : ITag
    {
    }

    public class ListGroup<THelper> : Tag<THelper, ListGroup<THelper>, ListGroupWrapper<THelper>>, IListGroup
        where THelper : BootstrapHelper<THelper>
    {
        internal ListGroup(IComponentCreator<THelper> creator)
            : base(creator, "div", Css.ListGroup)
        {
        }
    }
}
