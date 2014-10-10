using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Buttons
{
    internal interface IButtonToolbar : ITag
    {
    }

    public interface IButtonToolbarCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class ButtonToolbar<TModel> : Tag<TModel, ButtonToolbar<TModel>>, IButtonToolbar, IButtonGroupCreator<TModel>
    {
        internal ButtonToolbar(BootstrapHelper<TModel> helper)
            : base(helper, "div", Css.BtnToolbar)
        {
            MergeAttribute("role", "toolbar");
        }
    }
}
