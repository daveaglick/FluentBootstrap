using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface IInputGroupAddonCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class InputGroupAddonWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface IInputGroupAddon : ITag
    {
    }

    public class InputGroupAddon<TModel> : Tag<TModel, InputGroupAddon<TModel>, InputGroupAddonWrapper<TModel>>, IInputGroupAddon
    {
        internal InputGroupAddon(IComponentCreator<TModel> creator)
            : base(creator, "span", Css.InputGroupAddon)
        {
        }
    }
}
