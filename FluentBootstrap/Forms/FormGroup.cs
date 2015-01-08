using FluentBootstrap.Grids;
using FluentBootstrap.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class FormGroup : Tag, IHasGridColumnExtensions, IFormValidation,
        ICanCreate<ControlLabel>,
        ICanCreate<FormControl>,
        ICanCreate<HelpBlock>
    {
        private ControlLabel _label = null;
        private Tag _columnWrapper;
        private bool _columnWrapperBeforeLabel = false;

        internal ControlLabel ControlLabel
        {
            set { _label = value; }
        }

        internal bool HasLabel
        {
            get { return _label != null; }
        }

        internal bool? Horizontal { get; set; }

        internal FormGroup(IComponentCreator creator)
            : base(creator, "div", Css.FormGroup)
        {
        }
        
        protected override void OnStart<THelper>(THelper helper, TextWriter writer)
        {
            // Set column classes if we're horizontal          
            ComponentBuilder<THelper, FormGroup> builder = GetBuilder(helper, this);
            Form form = GetComponent<Form>(helper);
            if ((form != null && form.Horizontal && (!Horizontal.HasValue || Horizontal.Value)) || (Horizontal.HasValue && Horizontal.Value))
            {
                int labelWidth = form == null ? helper.DefaultFormLabelWidth : form.DefaultLabelWidth;

                // Set label column class
                if (_label != null && !_label.CssClasses.Any(x => x.StartsWith("col-")))
                {
                    _label.SetColumnClass(helper, "col-md-", labelWidth);
                }

                // Add column classes to this (these will get moved to a wrapper later in this method)
                if (!CssClasses.Any(x => x.StartsWith("col-")))
                {
                    builder.SetMd(helper.GridColumns - labelWidth);

                    // Also need to add an offset if no label
                    if (_label == null)
                    {
                        builder.SetMdOffset(labelWidth);
                    }
                }
            }
            else if (form != null && form.Horizontal)
            {
                // If the form is horizontal but we requested not to be, create a full-width column wrapper
                builder.SetMd(helper.GridColumns);
                _columnWrapperBeforeLabel = true;
            }

            // Move any grid column classes to a container class
            if (CssClasses.Any(x => x.StartsWith("col-")))
            {
                _columnWrapper = helper.Element("div").AddCss(CssClasses.Where(x => x.StartsWith("col-")).ToArray()).Component;
            }
            CssClasses.RemoveWhere(x => x.StartsWith("col-"));

            base.OnStart(helper, writer);

            // Write the column wrapper first if needed
            if (_columnWrapperBeforeLabel && _columnWrapper != null)
            {
                _columnWrapper.Start(helper, writer);
            }

            // Write the label
            if (_label != null)
            {
                _label.StartAndFinish(helper, writer);
            }

            // Write the column wrapper
            if (!_columnWrapperBeforeLabel && _columnWrapper != null)
            {
                _columnWrapper.Start(helper, writer);
            }
        }

        protected override void OnFinish<THelper>(THelper helper, TextWriter writer)
        {
            Pop(helper, _columnWrapper, writer);
            base.OnFinish(helper, writer);
        }
    }
}
