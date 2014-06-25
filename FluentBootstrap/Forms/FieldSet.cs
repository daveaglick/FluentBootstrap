using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface IFieldSet : IFormControl
    {
    }

    public interface IFieldSetCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class FieldSet<TModel> : Tag<TModel, FieldSet<TModel>>, IFieldSet, IHasDisabledAttribute,
        Forms.IFormGroupCreator<TModel>,
        Forms.ILabelCreator<TModel>,
        Forms.IFormControlCreator<TModel>,
        IHelpBlockCreator<TModel>
    {
        internal FieldSet(BootstrapHelper<TModel> helper)
            : base(helper, "fieldset")
        {
        }
    }
}
