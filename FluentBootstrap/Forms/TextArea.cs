using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface TextAreaCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class TextAreaWrapper<THelper> : FormControlWrapper<THelper>
    {
    }

    internal interface ITextArea : IFormControl
    {
    }

    public class TextArea<THelper> : FormControl<THelper, TextArea<THelper>, TextAreaWrapper<THelper>>, ITextArea, IHasNameAttribute
    {
        internal TextArea(IComponentCreator<THelper> creator)
            : base(creator, "textarea", Css.FormControl)
        {
        }
    }
}
