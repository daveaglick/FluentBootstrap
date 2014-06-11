using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class FormGroup : Tag, FluentBootstrap.Grids.IGridColumn, IFormValidation,
        Forms.Label.ICreate,
        Forms.Input.ICreate,
        Forms.CheckedControl.ICreate,
        Forms.Select.ICreate,
        Forms.TextArea.ICreate,
        Forms.Static.ICreate,
        Forms.FormButton.ICreate,
        Forms.InputButton.ICreate
    {
        internal Tag ColumnWrapper { get; set; }

        // This helps track if a label was written as part of this group so following inputs can adjust offset CSS classes accordingly
        internal bool WroteLabel { get; set; }

        internal FormGroup(BootstrapHelper helper) : base(helper, "div", "form-group")
        {

        }

        protected override void Prepare(System.IO.TextWriter writer)
        {
            base.Prepare(writer);

            // Add a column wrapper if we've got explictly set widths
            if (CssClasses.Any(x => x.StartsWith("col-")) && ColumnWrapper == null)
            {
                ColumnWrapper = new Tag(Helper, "div", CssClasses.Where(x => x.StartsWith("col-")).ToArray());
                ColumnWrapper.Start(writer, true);
            }
            CssClasses.RemoveWhere(x => x.StartsWith("col-"));
        }

        protected override void OnFinish(System.IO.TextWriter writer)
        {
            base.OnFinish(writer);
            Pop(ColumnWrapper, writer);
        }

        public interface ICreate : ICreateComponent
        {
        }
    }
}
