using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class TextArea<TModel> : FormControl<TModel>
    {
        internal TextArea(BootstrapHelper<TModel> helper)
            : base(helper, "textarea", "form-control")
        {
        }
    }
}
