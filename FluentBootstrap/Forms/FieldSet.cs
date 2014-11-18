using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface IFieldSetCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class FieldSetWrapper<THelper> : TagWrapper<THelper>,
        IFormGroupCreator<THelper>,
        IControlLabelCreator<THelper>,
        IFormControlCreator<THelper>,
        IHelpBlockCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IFieldSet : ITag
    {
    }

    public class FieldSet<THelper> : Tag<THelper, FieldSet<THelper>, FieldSetWrapper<THelper>>, IFieldSet, IHasDisabledAttribute
        where THelper : BootstrapHelper<THelper>
    {
        internal FieldSet(IComponentCreator<THelper> creator)
            : base(creator, "fieldset")
        {
        }
    }
}
