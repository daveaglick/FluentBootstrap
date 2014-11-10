using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Wells
{
    public interface IWellCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class WellWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface IWell : ITag
    {
    }

    public class Well<TModel> : Tag<TModel, Well<TModel>, WellWrapper<TModel>>, IWell
    {
        internal Well(IComponentCreator<TModel> creator)
            : base(creator, "div", Css.Well)
        {
        }
    }
}
