using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    internal interface IStatic : IFormControl
    {
    }

    public class Static<TModel> : FormControl<TModel, Static<TModel>>, IStatic
    {
        internal Static(BootstrapHelper<TModel> helper)
            : base(helper, "p", Css.FormControlStatic)
        {
        }
    }
}
