using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface ICiteCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class CiteWrapper<TModel> : TagWrapper<TModel>
    {
    }
    internal interface ICite : ITag
    {
    }

    public class Cite<TModel> : Tag<TModel, Cite<TModel>, CiteWrapper<TModel>>, ICite, IHasTextAttribute, IHasTitleAttribute
    {
        internal Cite(IComponentCreator<TModel> creator)
            : base(creator, "cite")
        {
        }
    }
}
