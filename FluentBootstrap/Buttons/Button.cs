using FluentBootstrap.Badges;
using FluentBootstrap.Icons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Buttons
{
    public interface IButtonCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class ButtonWrapper<THelper> : TagWrapper<THelper>,
        IBadgeCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IButton : ITag
    {
    }

    public class Button<THelper> : Tag<THelper, Button<THelper>, ButtonWrapper<THelper>>, IButton,
        IHasIconExtensions, IHasButtonExtensions, IHasButtonStateExtensions, IHasDisabledAttribute, IHasTextContent, IHasValueAttribute
        where THelper : BootstrapHelper<THelper>
    {
        private ButtonGroup<THelper> _buttonGroup;

        internal Button(IComponentCreator<THelper> creator, ButtonType buttonType) 
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
