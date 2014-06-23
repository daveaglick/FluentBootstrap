using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface IFormContent : IFormControl
    {
    }

    public class FormContent<TModel> : FormControl<TModel, FormContent<TModel>>
    {
        internal FormContent(BootstrapHelper<TModel> helper)
            : base(helper, "div", "form-control-static")
        {
        }
    }
}
