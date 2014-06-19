using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Buttons
{
    public interface ILinkButton : ITag
    {
    }

    public interface ILinkButtonCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class LinkButton<TModel> : Tag<TModel, LinkButton<TModel>>, ILinkButton, Links.IHasLinkExtensions, IHasButtonExtensions, IHasTextAttribute
    {
        internal LinkButton(BootstrapHelper<TModel> helper, ButtonStyle buttonStyle)
            : base(helper, "a", "btn", buttonStyle.GetDescription())
        {
            MergeAttribute("role", "button");
        }
    }
}
