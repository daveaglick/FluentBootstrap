using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface ITextArea : IFormControl
    {
    }

    public class TextArea<TModel> : FormControl<TModel, TextArea<TModel>>, ITextArea
    {
        internal TextArea(BootstrapHelper<TModel> helper)
            : base(helper, "textarea", "form-control")
        {
        }
    }
}
