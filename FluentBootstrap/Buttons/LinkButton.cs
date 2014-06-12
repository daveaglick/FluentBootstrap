using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Buttons
{
    public class LinkButton : Tag, Links.ILink, IButton, ITextAttribute
    {
        internal LinkButton(BootstrapHelper helper, ButtonStyle buttonStyle)
            : base(helper, "a", "btn", buttonStyle.GetDescription())
        {
            MergeAttribute("role", "button");
        }

        public interface ICreate : ICreateComponent
        {
        }
    }
}
