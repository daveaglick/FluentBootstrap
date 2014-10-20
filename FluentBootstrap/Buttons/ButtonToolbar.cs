using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Buttons
{
    public interface IButtonToolbarCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class ButtonToolbarWrapper<TModel> : TagWrapper<TModel>, IButtonGroupCreator<TModel>
    {
    }

    internal interface IButtonToolbar : ITag
    {
    }

    public class ButtonToolbar<TModel> : Tag<TModel, ButtonToolbar<TModel>, ButtonToolbarWrapper<TModel>>, IButtonToolbar
    {
        internal ButtonToolbar(IComponentCreator<TModel> creator)
            : base(creator, "div", Css.BtnToolbar)
        {
            MergeAttribute("role", "toolbar");
        }
    }
}
