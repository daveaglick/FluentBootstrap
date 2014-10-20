using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface IInputGroupCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class InputGroupWrapper<TModel> : TagWrapper<TModel>, 
        IInputGroupAddonCreator<TModel>, 
        IInputGroupButtonCreator<TModel>
    {
    }

    internal interface IInputGroup : ITag
    {
    }

    public class InputGroup<TModel> : Tag<TModel, InputGroup<TModel>, InputGroupWrapper<TModel>>, IInputGroup
    {
        internal InputGroup(IComponentCreator<TModel> creator)
            : base(creator, "div", Css.InputGroup)
        {
        }
    }
}
