using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Badges
{
    public interface IBadgeCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class BadgeWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface IBadge : ITag
    {
    }

    public class Badge<TModel> : Tag<TModel, Badge<TModel>, BadgeWrapper<TModel>>, IBadge, IHasTextAttribute
    {
        internal Badge(IComponentCreator<TModel> creator)
            : base(creator, "span", Css.Badge)
        {
        }
    }
}
