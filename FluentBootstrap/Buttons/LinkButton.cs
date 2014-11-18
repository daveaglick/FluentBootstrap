using FluentBootstrap.Icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentBootstrap.Links;

namespace FluentBootstrap.Buttons
{
    public interface ILinkButtonCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class ListButtonWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface ILinkButton : ITag
    {
    }

    public class LinkButton<THelper> : Tag<THelper, LinkButton<THelper>, ListButtonWrapper<THelper>>, ILinkButton,
        IHasIconExtensions, IHasLinkExtensions, IHasButtonExtensions, IHasButtonStateExtensions, IHasTextContent
        where THelper : BootstrapHelper<THelper>
    {
        internal LinkButton(IComponentCreator<THelper> creator)
            : base(creator, "a", Css.Btn, Css.BtnDefault)
        {
            MergeAttribute("role", "button");
        }
    }
}
