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

    public class InputButton<TModel> : FormControl<TModel, InputButton<TModel>>, IInputButton, Buttons.IHasButtonExtensions, Buttons.IHasButtonStyleExtensions, IHasDisabledAttribute, IHasTextAttribute, IHasValueAttribute, IHasNameAttribute
    {
        internal InputButton(BootstrapHelper<TModel> helper, ButtonType buttonType)
            : base(helper, "input", Css.Btn, Css.BtnDefault)
        {
            MergeAttribute("type", buttonType.GetDescription());
        }
    }
}
