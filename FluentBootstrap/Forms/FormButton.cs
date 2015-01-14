using FluentBootstrap.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    // This is like Button except it's derived from FormControl so it includes the form wrapping elements
    public class FormButton : FormControl, 
        IHasButtonExtensions, IHasButtonStateExtensions, 
        IHasValueAttribute, IHasDisabledAttribute, IHasTextContent, IHasNameAttribute
    {
        internal FormButton(BootstrapHelper helper, ButtonType buttonType)
            : base(helper, "button", Css.Btn, Css.BtnDefault)
        {
            MergeAttribute("type", buttonType.GetDescription());
        }
    }
}
