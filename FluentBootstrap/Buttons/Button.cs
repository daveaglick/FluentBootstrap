using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Buttons
{
    public class Button : Tag, IButton, IHasDisabledAttribute, IHasTextAttribute, IHasValueAttribute
    {
        internal Button(BootstrapHelper helper, ButtonType buttonType, ButtonStyle buttonStyle) 
            : base(helper, "button", "btn", buttonStyle.GetDescription())
        {
            MergeAttribute("type", buttonType.GetDescription());
        }

        public interface ICreate : ICreateComponent
        {
        }
    }
}
