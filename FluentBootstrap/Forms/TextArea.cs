using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    internal interface ITextArea : IFormControl
    {
    }

    public class TextArea<TModel> : FormControl<TModel, TextArea<TModel>>, ITextArea, IHasNameAttribute
    {
        internal TextArea(BootstrapHelper<TModel> helper)
            : base(helper, "textarea", Css.FormControl)
        {
        }
    }
}
