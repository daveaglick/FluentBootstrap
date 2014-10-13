using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    internal interface IInputGroup : ITag
    {
    }

    public interface IInputGroupCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class InputGroup<TModel> : Tag<TModel, InputGroup<TModel>>, IInputGroup, IInputGroupAddonCreator<TModel>, IInputGroupButtonCreator<TModel>
    {
        internal InputGroup(BootstrapHelper<TModel> helper)
            : base(helper, "div", Css.InputGroup)
        {
        }
    }
}
