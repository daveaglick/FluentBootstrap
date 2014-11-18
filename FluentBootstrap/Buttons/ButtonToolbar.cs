using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Buttons
{
    public interface IButtonToolbarCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class ButtonToolbarWrapper<THelper> : TagWrapper<THelper>, IButtonGroupCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IButtonToolbar : ITag
    {
    }

    public class ButtonToolbar<THelper> : Tag<THelper, ButtonToolbar<THelper>, ButtonToolbarWrapper<THelper>>, IButtonToolbar
        where THelper : BootstrapHelper<THelper>
    {
        internal ButtonToolbar(IComponentCreator<THelper> creator)
            : base(creator, "div", Css.BtnToolbar)
        {
            MergeAttribute("role", "toolbar");
        }
    }
}
