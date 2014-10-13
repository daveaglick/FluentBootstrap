using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    internal interface IInputGroupAddon : ITag
    {
    }

    public interface IInputGroupAddonCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class InputGroupAddon<TModel> : Tag<TModel, InputGroupAddon<TModel>>, IInputGroupAddon
    {
        internal InputGroupAddon(BootstrapHelper<TModel> helper)
            : base(helper, "span", Css.InputGroupAddon)
        {
        }
    }
}
