using FluentBootstrap.Dropdowns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Buttons
{
    public interface IDropdownButtonCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class DropdownButtonWrapper<THelper> : TagWrapper<THelper>, 
        IButtonCreator<THelper>, 
        ILinkButtonCreator<THelper>,
        IDropdownCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IDropdownButton : ITag
    {
    }

    public class DropdownButton<THelper> : Tag<THelper, DropdownButton<THelper>, DropdownButtonWrapper<THelper>>, IDropdownButton
        where THelper : BootstrapHelper<THelper>
    {
        internal DropdownButton(IComponentCreator<THelper> creator)
            : base(creator, "div", Css.BtnGroup)
        {
        }
    }
}
