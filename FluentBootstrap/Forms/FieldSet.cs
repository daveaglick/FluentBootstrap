using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface IFieldSetCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class FieldSetWrapper<TModel> : TagWrapper<TModel>,
        IFormGroupCreator<TModel>,
        ILabelCreator<TModel>,
        IFormControlCreator<TModel>,
        IHelpBlockCreator<TModel>
    {
    }

    internal interface IFieldSet : IFormControl
    {
    }

    public class FieldSet<TModel> : Tag<TModel, FieldSet<TModel>, FieldSetWrapper<TModel>>, IFieldSet, IHasDisabledAttribute
    {
        internal FieldSet(IComponentCreator<TModel> creator)
            : base(creator, "fieldset")
        {
        }
    }
}
