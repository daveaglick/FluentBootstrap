using FluentBootstrap.Dropdowns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Buttons
{
    internal interface IDropdownButton : ITag
    {
    }

    public interface IDropdownButtonCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class DropdownButton<TModel> : Tag<TModel, DropdownButton<TModel>>, IDropdownButton, IButtonCreator<TModel>, ILinkButtonCreator<TModel>, IDropdownCreator<TModel>
    {
        internal DropdownButton(BootstrapHelper<TModel> helper)
            : base(helper, "div", Css.BtnGroup)
        {
        }
    }
}
