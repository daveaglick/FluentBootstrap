using FluentBootstrap.Buttons;
using FluentBootstrap.Dropdowns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    internal interface IInputGroupButton : ITag
    {
    }

    public interface IInputGroupButtonCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class InputGroupButton<TModel> : Tag<TModel, InputGroupButton<TModel>>, IInputGroupButton, IButtonCreator<TModel>, IDropdownCreator<TModel>
    {
        internal InputGroupButton(BootstrapHelper<TModel> helper)
            : base(helper, "span", Css.InputGroupBtn)
        {
        }
    }
}
