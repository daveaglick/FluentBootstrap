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
        //IFormButton, IHasButtonExtensions, IHasButtonStateExtensions, 
        IHasValueAttribute, IHasDisabledAttribute, IHasTextContent, IHasNameAttribute
    {
        internal FormButton(IComponentCreator creator, ButtonType buttonType)
            : base(creator, "button", Css.Btn, Css.BtnDefault)
        {
            MergeAttribute("type", buttonType.GetDescription());
        }
    }
}
