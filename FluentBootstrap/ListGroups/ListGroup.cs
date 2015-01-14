using FluentBootstrap.Badges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.ListGroups
{
    public interface IListGroupCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class ListGroupWrapper<TConfig> : TagWrapper<TConfig>,
        IListGroupItemCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface IListGroup : ITag
    {
    }

    public class ListGroup<TConfig> : Tag<TConfig, ListGroup<TConfig>, ListGroupWrapper<TConfig>>, IListGroup
        where TConfig : BootstrapConfig
    {
        internal ListGroup(BootstrapHelper helper)
            : base(helper, "div", Css.ListGroup)
        {
        }
    }
}
