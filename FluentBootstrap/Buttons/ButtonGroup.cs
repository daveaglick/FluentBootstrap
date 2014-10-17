using FluentBootstrap.Dropdowns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Buttons
{
    public interface IButtonGroupCreator<TModel> : ITagCreator<TModel>
    {
    }

    public class ButtonGroupWrapper<TModel> : TagWrapper<TModel>, IButtonCreator<TModel>, ILinkButtonCreator<TModel>, IDropdownCreator<TModel>
    {
    }

    internal interface IButtonGroup : ITag
    {
    }

    public class ButtonGroup<TModel> : Tag<TModel, ButtonGroup<TModel>, ButtonGroupWrapper<TModel>>, IButtonGroup
    {
        internal ButtonGroup(IComponentCreator<TModel> creator)
            : base(creator, "div", Css.BtnGroup)
        {
        }
    }
}
