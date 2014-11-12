using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface IStaticCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class StaticWrapper<THelper> : FormControlWrapper<THelper>
    {
    }

    internal interface IStatic : IFormControl
    {
    }

    public class Static<THelper> : FormControl<THelper, Static<THelper>, StaticWrapper<THelper>>, IStatic
    {
        internal Static(IComponentCreator<THelper> creator)
            : base(creator, "p", Css.FormControlStatic)
        {
        }
    }
}
