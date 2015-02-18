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

        public ControlLabel ControlLabel
        {
            set { _label = value; }
        }

        public bool HasLabel
        {
            get { return _label != null; }
        }
        
        public Icon Icon { get; set; }

        public bool? Horizontal { get; set; }   // null = same as the form, or false if no form

        public bool AutoColumns { get; set; }   // indicates if columns should automatically be generated if horizontal

        internal FormGroup(BootstrapHelper helper)
            : base(helper, "div", Css.FormGroup)
        {
            Icon = Icon.None;
            AutoColumns = true;
        }
        
        protected override void OnStart(TextWriter writer)
        {
            // Set column classes if we're horizontal       
            if (AutoColumns)
            {
                ComponentBuilder<BootstrapConfig, FormGroup> builder = GetBuilder(this);
                Form form = GetComponent<Form>();
                if ((form != null && form.Horizontal && (!Horizontal.HasValue || Horizontal.Value)) || (Horizontal.HasValue && Horizontal.Value))
                {
                    int labelWidth = form == null ? Config.DefaultFormLabelWidth : form.DefaultLabelWidth;

                    // Set label column class
                    if (_label != null && !_label.CssClasses.Any(x => x.StartsWith("col-")))
                    {
                        _label.SetColumnClass(Config, "col-md-", labelWidth);
                    }

                    // Add column classes to this (these will get moved to a wrapper later in this method)
                    if (!CssClasses.Any(x => x.StartsWith("col-")))
                    {
                        builder.SetMd(Config.GridColumns - labelWidth);

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
                    builder.SetMd(Config.GridColumns);
                    _columnWrapperBeforeLabel = true;
                }
            }

            // Move any grid column classes to a container class
            if (CssClasses.Any(x => x.StartsWith("col-")))
            {
                _columnWrapper = GetHelper().Element("div").AddCss(CssClasses.Where(x => x.StartsWith("col-")).ToArray()).Component;
            }
            CssClasses.RemoveWhere(x => x.StartsWith("col-"));

            base.OnStart(writer);

            // Write the column wrapper first if needed
            if (_columnWrapperBeforeLabel && _columnWrapper != null)
            {
                _columnWrapper.Start(writer);
            }

            // Write the label
            if (_label != null)
            {
                _label.StartAndFinish(writer);
            }

            // Write the column wrapper
            if (!_columnWrapperBeforeLabel && _columnWrapper != null)
            {
                _columnWrapper.Start(writer);
            }
            
            // Add the feedback icon as a final child of either this or the wrapper
            if (Icon != Icon.None)
            {
                Component icon = GetHelper().Icon(Icon).AddCss(Css.FormControlFeedback).Component;
                if(_columnWrapper == null)
                {
                    AddChildAtEnd(icon);
                }
                else
                {
                    _columnWrapper.AddChildAtEnd(icon);
                }
            }
        }

        protected override void OnFinish(TextWriter writer)
        {
            Pop(_columnWrapper, writer);

            base.OnFinish(writer);
        }
    }
}
