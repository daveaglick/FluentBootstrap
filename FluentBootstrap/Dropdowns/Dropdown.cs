using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Dropdowns
{
    internal interface IDropdown : ITag
    {
    }

    public interface IDropdownCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class Dropdown<TModel> : Tag<TModel, Dropdown<TModel>>, IDropdown//,
        //IPanelSectionCreator<TModel>,
        //IPanelTitleCreator<TModel>
    {

        internal Dropdown(BootstrapHelper<TModel> helper)
            : base(helper, "div", Css.Panel, Css.PanelDefault)
        {
        }
    }
}
