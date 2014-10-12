using FluentBootstrap.Icons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Buttons
{
    internal interface IButton : ITag
    {
    }

    public interface IButtonCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class Button<TModel> : Tag<TModel, Button<TModel>>, IButton, IHasIconExtensions, IHasButtonExtensions, IHasButtonStyleExtensions, IHasDisabledAttribute, IHasTextAttribute, IHasValueAttribute
    {
        private ButtonGroup<TModel> _buttonGroup;

        internal Button(BootstrapHelper<TModel> helper, ButtonType buttonType) 
            : base(helper, "button", Css.Btn, Css.BtnDefault)
        {
            MergeAttribute("type", buttonType.GetDescription());
        }

        protected override void PreStart(TextWriter writer)
        {
            // Fix for justified buttons in a group (need to surround them with an extra button group)
            // See https://github.com/twbs/bootstrap/issues/12476
            IButtonGroup buttonGroup = GetComponent<IButtonGroup>(true);
            if (buttonGroup != null && buttonGroup.CssClasses.Contains(Css.BtnGroupJustified))
            {
                _buttonGroup = Helper.ButtonGroup();
                _buttonGroup.Start(writer, true);
            }

            base.PreStart(writer);
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
