using FluentBootstrap.Dropdowns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Buttons
{
    public interface IButtonGroupCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class ButtonGroupWrapper<THelper> : TagWrapper<THelper>, 
        IButtonCreator<THelper>, 
        ILinkButtonCreator<THelper>,
        IDropdownCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IButtonGroup : ITag
    {
    }

    public class ButtonGroup<THelper> : Tag<THelper, ButtonGroup<THelper>, ButtonGroupWrapper<THelper>>, IButtonGroup
        where THelper : BootstrapHelper<THelper>
    {
        internal ButtonGroup(IComponentCreator<THelper> creator)
            : base(creator, "div", Css.BtnGroup)
        {
        }
    }
}
