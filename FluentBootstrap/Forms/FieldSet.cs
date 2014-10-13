using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    internal interface IFieldSet : IFormControl
    {
    }

    public interface IFieldSetCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class FieldSet<TModel> : Tag<TModel, FieldSet<TModel>>, IFieldSet, IHasDisabledAttribute,
        IFormGroupCreator<TModel>,
        ILabelCreator<TModel>,
        IFormControlCreator<TModel>,
        IHelpBlockCreator<TModel>
    {
        internal FieldSet(BootstrapHelper<TModel> helper)
            : base(helper, "fieldset")
        {
        }
    }
}
