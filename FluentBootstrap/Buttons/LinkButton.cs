using FluentBootstrap.Icons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentBootstrap.Links;

namespace FluentBootstrap.Buttons
{
    public class LinkButton : Tag,
        IHasIconExtensions, IHasLinkExtensions, IHasButtonExtensions, IHasButtonStateExtensions, IHasTextContent
    {
        internal LinkButton(BootstrapHelper helper)
            : base(helper, "a", Css.Btn, Css.BtnDefault)
        {
            MergeAttribute("role", "button");
        }
    }
}
