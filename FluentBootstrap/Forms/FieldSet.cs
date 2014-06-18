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
        Forms.Input.ICreate,
        Forms.CheckedControl.ICreate,
        Forms.Select.ICreate,
        Forms.TextArea.ICreate,
        Forms.Static.ICreate,
        Forms.FormButton.ICreate,
        Forms.InputButton.ICreate
    {
        internal FieldSet(BootstrapHelper helper) : base(helper, "fieldset")
        {
        }

        public interface ICreate : ICreateComponent
        {
        }
    }
}
