using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    internal interface IInputButton : IFormControl
    {
    }

    public class InputButton<TModel> : FormControl<TModel, InputButton<TModel>>, IInputButton, Buttons.IHasButtonExtensions, IHasDisabledAttribute, IHasTextAttribute, IHasValueAttribute, IHasNameAttribute
    {
        internal InputButton(BootstrapHelper<TModel> helper, ButtonType buttonType, ButtonStyle buttonStyle)
            : base(helper, "input", "btn", buttonStyle.GetDescription())
        {
            MergeAttribute("type", buttonType.GetDescription());
        }
    }
}
