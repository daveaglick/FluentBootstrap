using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class FieldSet : Tag, IHasDisabledAttribute,
        Forms.FormGroup.ICreate,
        Forms.Label.ICreate,
        Forms.FormControl.ICreate
    {
        internal FieldSet(BootstrapHelper helper) : base(helper, "fieldset")
        {
        }

        public interface ICreate : ICreateComponent
        {
        }
    }
}
