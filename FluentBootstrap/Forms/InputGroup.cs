using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface IInputGroupCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class InputGroupWrapper<THelper> : TagWrapper<THelper>, 
        IInputGroupAddonCreator<THelper>, 
        IInputGroupButtonCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IInputGroup : ITag
    {
    }

    public class InputGroup<THelper> : Tag<THelper, InputGroup<THelper>, InputGroupWrapper<THelper>>, IInputGroup
        where THelper : BootstrapHelper<THelper>
    {
        internal InputGroup(IComponentCreator<THelper> creator)
            : base(creator, "div", Css.InputGroup)
        {
        }
    }
}
