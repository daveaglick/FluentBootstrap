using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface TextAreaCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class TextAreaWrapper<TModel> : FormControlWrapper<TModel>
    {
    }

    internal interface ITextArea : IFormControl
    {
    }

    public class TextArea<TModel> : FormControl<TModel, TextArea<TModel>, TextAreaWrapper<TModel>>, ITextArea, IHasNameAttribute
    {
        internal TextArea(IComponentCreator<TModel> creator)
            : base(creator, "textarea", Css.FormControl)
        {
        }
    }
}
