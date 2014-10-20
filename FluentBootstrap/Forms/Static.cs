using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface IStaticCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class StaticWrapper<TModel> : FormControlWrapper<TModel>
    {
    }

    internal interface IStatic : IFormControl
    {
    }

    public class Static<TModel> : FormControl<TModel, Static<TModel>, StaticWrapper<TModel>>, IStatic
    {
        internal Static(IComponentCreator<TModel> creator)
            : base(creator, "p", Css.FormControlStatic)
        {
        }
    }
}
