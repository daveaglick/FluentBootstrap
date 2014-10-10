using FluentBootstrap.Dropdowns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Buttons
{
    internal interface IButtonGroup : ITag
    {
    }

    public interface IButtonGroupCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class ButtonGroup<TModel> : Tag<TModel, ButtonGroup<TModel>>, IButtonGroup, IButtonCreator<TModel>, ILinkButtonCreator<TModel>, IDropdownCreator<TModel>
    {
        internal ButtonGroup(BootstrapHelper<TModel> helper)
            : base(helper, "div", Css.BtnGroup)
        {
        }
    }
}
