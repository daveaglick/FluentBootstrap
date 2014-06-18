using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentBootstrap.Forms
{
    public class Input<TModel> : FormControl<TModel>, IHasValueAttribute
    {
        internal Input(BootstrapHelper<TModel> helper, FormInputType inputType)
            : base(helper, "input", "form-control")
        {
            MergeAttribute("type", inputType.GetDescription());
        }
    }
}
