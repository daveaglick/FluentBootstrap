using FluentBootstrap.Buttons;
using FluentBootstrap.Dropdowns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface IInputGroupButtonCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class InputGroupButtonWrapper<THelper> : TagWrapper<THelper>, 
        IButtonCreator<THelper>, 
        IDropdownCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IInputGroupButton : ITag
    {
    }

    public class InputGroupButton<THelper> : Tag<THelper, InputGroupButton<THelper>, InputGroupButtonWrapper<THelper>>, IInputGroupButton
        where THelper : BootstrapHelper<THelper>
    {
        internal InputGroupButton(IComponentCreator<THelper> creator)
            : base(creator, "span", Css.InputGroupBtn)
        {
        }
    }
}
