using FluentBootstrap.Buttons;
using FluentBootstrap.Dropdowns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface IInputGroupButtonCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class InputGroupButtonWrapper<TModel> : TagWrapper<TModel>, 
        IButtonCreator<TModel>, 
        IDropdownCreator<TModel>
    {
    }

    internal interface IInputGroupButton : ITag
    {
    }

    public class InputGroupButton<TModel> : Tag<TModel, InputGroupButton<TModel>, InputGroupButtonWrapper<TModel>>, IInputGroupButton
    {
        internal InputGroupButton(IComponentCreator<TModel> creator)
            : base(creator, "span", Css.InputGroupBtn)
        {
        }
    }
}
