using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface IInputGroupAddonCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class InputGroupAddonWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IInputGroupAddon : ITag
    {
    }

    public class InputGroupAddon<THelper> : Tag<THelper, InputGroupAddon<THelper>, InputGroupAddonWrapper<THelper>>, IInputGroupAddon
        where THelper : BootstrapHelper<THelper>
    {
        internal InputGroupAddon(IComponentCreator<THelper> creator)
            : base(creator, "span", Css.InputGroupAddon)
        {
        }
    }
}
