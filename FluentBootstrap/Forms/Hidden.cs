using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface IHiddenCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class HiddenWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface IHidden : ITag
    {
    }

    public class Hidden<TModel> : Tag<TModel, Hidden<TModel>, HiddenWrapper<TModel>>, IHidden, IHasValueAttribute
    {
        internal Hidden(IComponentCreator<TModel> creator)
            : base(creator, "input")
        {
            MergeAttribute("type", "hidden");
        }
    }
}
