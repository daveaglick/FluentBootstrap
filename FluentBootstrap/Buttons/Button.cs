using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Buttons
{
    public class Button<TModel> : Tag<TModel>, IButton, IHasDisabledAttribute, IHasTextAttribute, IHasValueAttribute
    {
        internal Button(BootstrapHelper<TModel> helper, ButtonType buttonType, ButtonStyle buttonStyle) 
            : base(helper, "button", "btn", buttonStyle.GetDescription())
        {
            MergeAttribute("type", buttonType.GetDescription());
        }

        public interface ICreate : ICreateComponent<TModel>
        {
        }
    }
}
