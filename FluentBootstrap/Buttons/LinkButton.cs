using FluentBootstrap.Icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentBootstrap.Links;

namespace FluentBootstrap.Buttons
{
    public interface ILinkButtonCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class ListButtonWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface ILinkButton : ITag
    {
    }

    public class LinkButton<TModel> : Tag<TModel, LinkButton<TModel>, ListButtonWrapper<TModel>>, ILinkButton, IHasIconExtensions, IHasLinkExtensions, IHasButtonExtensions, IHasButtonStateExtensions, IHasTextContent
    {
        internal LinkButton(IComponentCreator<TModel> creator)
            : base(creator, "a", Css.Btn, Css.BtnDefault)
        {
            MergeAttribute("role", "button");
        }
    }
}
