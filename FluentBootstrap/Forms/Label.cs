using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface ILabel : ITag
    {
    }

    public interface ILabelCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class Label<TModel> : Tag<TModel, Label<TModel>>, ILabel, FluentBootstrap.Grids.IHasGridColumnExtensions, IHasTextAttribute
    {
        internal Label(BootstrapHelper<TModel> helper, string text)
            : base(helper, "label", "control-label")
        {
            TextContent = text;
        }

        protected override void Prepare(TextWriter writer)
        {
            base.Prepare(writer);

            // Set default column classes if we're horizontal and we haven't already written one
            Form<TModel> form = GetComponent<Form<TModel>>();
            FormGroup<TModel> formGroup = GetComponent<FormGroup<TModel>>();
            if (form != null && form.Horizontal && form.DefaultLabelWidth != null 
                && formGroup != null && !formGroup.WroteLabel
                && !CssClasses.Any(x => x.StartsWith("col-")))
            {
                this.Md(form.DefaultLabelWidth);
            }
        }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);

            // Track that a label was written as part of this form group
            FormGroup<TModel> formGroup = GetComponent<FormGroup<TModel>>();
            if (formGroup != null)
            {
                formGroup.WroteLabel = true;
            }
        }
    }
}
