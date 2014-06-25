using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public interface IFormGroup : ITag
    {
    }

    public interface IFormGroupCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class FormGroup<TModel> : Tag<TModel, FormGroup<TModel>>, IFormGroup, FluentBootstrap.Grids.IHasGridColumnExtensions, IFormValidation,
        Forms.ILabelCreator<TModel>,
        Forms.IFormControlCreator<TModel>,
        IHelpBlockCreator<TModel>
    {
        private Label<TModel> _label = null;
        private Tag<TModel> _columnWrapper;

        internal Label<TModel> Label
        {
            set
            {
                _label = value;                
                PendingComponents.Remove(HtmlHelper, value);    // Need to remove this from the pending components since it's similar to a child and will be output from this form control
            }
        }

        internal bool HasLabel
        {
            get { return _label != null; }
        }

        internal FormGroup(BootstrapHelper<TModel> helper)
            : base(helper, "div", "form-group")
        {

        }

        protected override void PreStart(TextWriter writer)
        {
            base.PreStart(writer);

            // Set column classes if we're horizontal            
            Form<TModel> form = GetComponent<Form<TModel>>();
            if (form != null && form.Horizontal)
            {
                // Set label column class
                if (_label != null && !_label.CssClasses.Any(x => x.StartsWith("col-")))
                {
                    _label.Md(form.DefaultLabelWidth);
                }

                // Add column classes to this (these will get moved to a wrapper later in this method)
                if (!CssClasses.Any(x => x.StartsWith("col-")))
                {
                    this.Md(Bootstrap.GridColumns - form.DefaultLabelWidth);

                    // Also need to add an offset if no label
                    if (_label == null)
                    {
                        this.MdOffset(form.DefaultLabelWidth);
                    }
                }
            }

            // Move any grid column classes to a container class
            if (CssClasses.Any(x => x.StartsWith("col-")))
            {
                _columnWrapper = new Tag<TModel>(Helper, "div", CssClasses.Where(x => x.StartsWith("col-")).ToArray());
                PendingComponents.Remove(HtmlHelper, _columnWrapper);    // Need to remove this from the pending components since it'll be output during OnStart
            }
            CssClasses.RemoveWhere(x => x.StartsWith("col-"));
        }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);

            // Write the label
            if (_label != null)
            {
                _label.StartAndFinish(writer);
            }

            // Write the column wrapper
            if (_columnWrapper != null)
            {
                _columnWrapper.Start(writer, true);
            }
        }

        protected override void OnFinish(TextWriter writer)
        {
            Pop(_columnWrapper, writer);
            base.OnFinish(writer);
        }
    }
}
