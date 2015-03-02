using FluentBootstrap.Icons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class Input : FormControl, IHasValueAttribute, IHasNameAttribute
    {
        public Icon Icon { get; set; }

        internal Input(BootstrapHelper helper, FormInputType inputType)
            : base(helper, "input", Css.FormControl)
        {
            OutputEndTag = false;
            Icon = Icon.None;
            MergeAttribute("type", inputType.GetDescription());
        }

        protected override void OnFinish(TextWriter writer)
        {
            // Add the feedback icon
            if (Icon != Icon.None)
            {
                GetHelper().Icon(Icon).AddCss(Css.FormControlFeedback).Component.StartAndFinish(writer);
            }

            base.OnFinish(writer);
        }
    }
}
