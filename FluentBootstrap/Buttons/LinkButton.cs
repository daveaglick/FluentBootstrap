using FluentBootstrap.Icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Buttons
{
    internal interface ILinkButton : ITag
    {
    }

    public interface ILinkButtonCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class LinkButton<TModel> : Tag<TModel, LinkButton<TModel>>, ILinkButton, IHasIconExtensions, Links.IHasLinkExtensions, IHasButtonExtensions, IHasButtonStyleExtensions, IHasTextAttribute
    {
        internal LinkButton(BootstrapHelper<TModel> helper)
            : base(helper, "a", Css.Btn, Css.BtnDefault)
        {
            MergeAttribute("role", "button");
        }
    }
}
