using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface ISmallCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class SmallWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface ISmall : ITag
    {
    }

    public class Small<TModel> : Tag<TModel, Small<TModel>, SmallWrapper<TModel>>, ISmall, IHasTextContent
    {
        internal Small(IComponentCreator<TModel> creator)
            : base(creator, "small")
        {
        }
    }
}
