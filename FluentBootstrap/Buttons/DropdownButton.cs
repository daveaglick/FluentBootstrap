using FluentBootstrap.Dropdowns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Buttons
{
    public interface IDropdownButtonCreator<TModel> : ITagCreator<TModel>
    {
    }

    public class DropdownButtonWrapper<TModel> : TagWrapper<TModel>, IButtonCreator<TModel>, ILinkButtonCreator<TModel>, IDropdownCreator<TModel>
    {
    }

    internal interface IDropdownButton : ITag
    {
    }

    public class DropdownButton<TModel> : Tag<TModel, DropdownButton<TModel>, DropdownButtonWrapper<TModel>>, IDropdownButton
    {
        internal DropdownButton(IComponentCreator<TModel> creator)
            : base(creator, "div", Css.BtnGroup)
        {
        }
    }
}
