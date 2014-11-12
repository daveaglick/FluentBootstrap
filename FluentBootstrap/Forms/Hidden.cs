using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface IHiddenCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class HiddenWrapper<THelper> : TagWrapper<THelper>
    {
    }

    internal interface IHidden : ITag
    {
    }

    public class Hidden<THelper> : Tag<THelper, Hidden<THelper>, HiddenWrapper<THelper>>, IHidden, IHasValueAttribute
    {
        internal Hidden(IComponentCreator<THelper> creator)
            : base(creator, "input")
        {
            MergeAttribute("type", "hidden");
        }
    }
}
