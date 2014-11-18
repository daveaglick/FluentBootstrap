using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Badges
{
    public interface IBadgeCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class BadgeWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IBadge : ITag
    {
    }

    public class Badge<THelper> : Tag<THelper, Badge<THelper>, BadgeWrapper<THelper>>, IBadge, IHasTextContent
        where THelper : BootstrapHelper<THelper>
    {
        internal Badge(IComponentCreator<THelper> creator)
            : base(creator, "span", Css.Badge)
        {
        }
    }
}
