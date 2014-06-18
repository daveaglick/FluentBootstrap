using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class InputButton : FormControl, Buttons.IButton, IHasDisabledAttribute, IHasTextAttribute, IHasValueAttribute
    {
        internal InputButton(BootstrapHelper helper, ButtonType buttonType, ButtonStyle buttonStyle)
            : base(helper, "input", "btn", buttonStyle.GetDescription())
        {
            MergeAttribute("type", buttonType.GetDescription());
        }

        public interface ICreate : ICreateComponent
        {
        }
    }
}
