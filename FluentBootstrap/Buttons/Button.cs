using FluentBootstrap.Icons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Buttons
{
    public interface IButtonCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class ButtonWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface IButton : ITag
    {
    }

    public class Button<TModel> : Tag<TModel, Button<TModel>, ButtonWrapper<TModel>>, IButton, IHasIconExtensions, IHasButtonExtensions, IHasButtonStateExtensions, IHasDisabledAttribute, IHasTextAttribute, IHasValueAttribute
    {
        private ButtonGroup<TModel> _buttonGroup;

        internal Button(IComponentCreator<TModel> creator, ButtonType buttonType) 
            : base(creator, "button", Css.Btn, Css.BtnDefault)
        {
            MergeAttribute("type", buttonType.GetDescription());
        }
        
        protected override void OnStart(TextWriter writer)
        {
            // Fix for justified buttons in a group (need to surround them with an extra button group)
            // See https://github.com/twbs/bootstrap/issues/12476
            IButtonGroup buttonGroup = GetComponent<IButtonGroup>(true);
            if (buttonGroup != null && buttonGroup.CssClasses.Contains(Css.BtnGroupJustified))
            {
                _buttonGroup = Helper.ButtonGroup();
                _buttonGroup.Start(writer);
            }

            base.OnStart(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            base.OnFinish(writer);
            
            if (_buttonGroup != null)
            {
                _buttonGroup.Finish(writer);
            }
        }
    }
}
