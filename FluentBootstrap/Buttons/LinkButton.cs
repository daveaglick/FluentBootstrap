using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Buttons
{
    public class LinkButton<TModel> : Tag<TModel>, Links.ILink, IButton, IHasTextAttribute
    {
        internal LinkButton(BootstrapHelper<TModel> helper, ButtonStyle buttonStyle)
            : base(helper, "a", "btn", buttonStyle.GetDescription())
        {
            MergeAttribute("role", "button");
        }

        public interface ICreate : ICreateComponent<TModel>
        {
        }
    }
}
