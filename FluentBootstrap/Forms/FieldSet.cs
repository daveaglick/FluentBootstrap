using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class FieldSet<TModel> : Tag<TModel>, IHasDisabledAttribute,
        Forms.FormGroup<TModel>.ICreate,
        Forms.Label<TModel>.ICreate,
        Forms.FormControl<TModel>.ICreate
    {
        internal FieldSet(BootstrapHelper<TModel> helper)
            : base(helper, "fieldset")
        {
        }

        public interface ICreate : ICreateComponent<TModel>
        {
        }
    }
}
