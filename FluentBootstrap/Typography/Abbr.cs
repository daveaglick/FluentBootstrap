using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Typography
{
    public interface IAbbrCreator<TModel> : ITagCreator<TModel>
    {
    }

    public class AbbrWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface IAbbr : ITag
    {
    }

    public class Abbr<TModel> : Tag<TModel, Abbr<TModel>, AbbrWrapper<TModel>>, IAbbr, IHasTextAttribute, IHasTitleAttribute
    {
        internal Abbr(IComponentCreator<TModel> creator, params string[] cssClasses)
            : base(creator, "abbr", cssClasses)
        {
        }
    }
}
