using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Wells
{
    public interface IWellCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class WellWrapper<THelper> : TagWrapper<THelper>
    {
    }

    internal interface IWell : ITag
    {
    }

    public class Well<THelper> : Tag<THelper, Well<THelper>, WellWrapper<THelper>>, IWell
    {
        internal Well(IComponentCreator<THelper> creator)
            : base(creator, "div", Css.Well)
        {
        }
    }
}
