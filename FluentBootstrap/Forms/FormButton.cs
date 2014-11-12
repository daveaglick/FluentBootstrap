using FluentBootstrap.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace FluentBootstrap.Forms
{
    public interface IFormButtonCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class FormButtonWrapper<THelper> : FormControlWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IFormButton : IFormControl
    {
    }

    // This is like Button except it's derived from FormControl so it includes the form wrapping elements
    public class FormButton<THelper> : FormControl<THelper, FormButton<THelper>, FormButtonWrapper<THelper>>, 
        IFormButton, IHasButtonExtensions, IHasButtonStateExtensions, IHasValueAttribute, IHasDisabledAttribute, IHasTextContent, IHasNameAttribute
        where THelper : BootstrapHelper<THelper>
    {
        internal FormButton(IComponentCreator<THelper> creator, ButtonType buttonType)
            : base(creator, "button", Css.Btn, Css.BtnDefault)
        {
            MergeAttribute("type", buttonType.GetDescription());
        }
    }
}
