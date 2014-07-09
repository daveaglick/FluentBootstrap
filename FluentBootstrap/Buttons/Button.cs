using System;
using System.Collections.Generic;
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

    public class Button<TModel> : Tag<TModel, Button<TModel>>, IButton, IHasButtonExtensions, IHasDisabledAttribute, IHasTextAttribute, IHasValueAttribute
    {
        internal Button(BootstrapHelper<TModel> helper, ButtonType buttonType, ButtonStyle buttonStyle) 
            : base(helper, "button", Css.Btn, buttonStyle.GetDescription())
        {
            MergeAttribute("type", buttonType.GetDescription());
        }
    }
}
