using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface IPreCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class PreWrapper<TModel> : TagWrapper<TModel>
    {
    }
    internal interface IPre : ITag
    {
    }

    public class Pre<TModel> : Tag<TModel, Pre<TModel>, PreWrapper<TModel>>, IPre, IHasTextContent
    {
        internal Pre(IComponentCreator<TModel> creator)
            : base(creator, "pre")
        {
        }
    }
}
