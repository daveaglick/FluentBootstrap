using FluentBootstrap.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface IInputButtonCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class InputButtonWrapper<TModel> : FormControlWrapper<TModel>
    {
    }

    internal interface IInputButton : IFormControl
    {
    }

    public class InputButton<TModel> : FormControl<TModel, InputButton<TModel>, InputButtonWrapper<TModel>>, 
        IInputButton, IHasButtonExtensions, IHasButtonStateExtensions, IHasDisabledAttribute, IHasTextAttribute, IHasValueAttribute, IHasNameAttribute
    {
        internal InputButton(IComponentCreator<TModel> creator, ButtonType buttonType)
            : base(creator, "input", Css.Btn, Css.BtnDefault)
        {
            MergeAttribute("type", buttonType.GetDescription());
        }

        protected override bool OutputEndTag
        {
            get { return false; }
        }
    }
}
