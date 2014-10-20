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
    public interface IFormButtonCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class FormButtonWrapper<TModel> : FormControlWrapper<TModel>
    {
    }

    internal interface IFormButton : IFormControl
    {
    }

    // This is like Button except it's derived from FormControl so it includes the form wrapping elements
    public class FormButton<TModel> : FormControl<TModel, FormButton<TModel>, FormButtonWrapper<TModel>>, 
        IFormButton, IHasButtonExtensions, IHasButtonStateExtensions, IHasValueAttribute, IHasDisabledAttribute, IHasTextAttribute, IHasNameAttribute
    {
        internal FormButton(IComponentCreator<TModel> creator, ButtonType buttonType)
            : base(creator, "button", Css.Btn, Css.BtnDefault)
        {
            MergeAttribute("type", buttonType.GetDescription());
        }
    }
}
