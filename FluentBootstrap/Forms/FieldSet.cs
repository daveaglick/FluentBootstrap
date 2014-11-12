using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface IFieldSetCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class FieldSetWrapper<THelper> : TagWrapper<THelper>,
        IFormGroupCreator<THelper>,
        IControlLabelCreator<THelper>,
        IFormControlCreator<THelper>,
        IHelpBlockCreator<THelper>
    {
    }

    internal interface IFieldSet : IFormControl
    {
    }

    public class FieldSet<THelper> : Tag<THelper, FieldSet<THelper>, FieldSetWrapper<THelper>>, IFieldSet, IHasDisabledAttribute
    {
        internal FieldSet(IComponentCreator<THelper> creator)
            : base(creator, "fieldset")
        {
        }
    }
}
