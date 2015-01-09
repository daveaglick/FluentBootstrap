using FluentBootstrap.Icons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Forms
{
    public class Input<THelper> : FormControl, IHasValueAttribute, IHasNameAttribute
    {
        public Icon Icon { get; set; }

        internal Input(IComponentCreator creator, FormInputType inputType)
            : base(creator, "input", Css.FormControl)
        {
            MergeAttribute("type", inputType.GetDescription());
        }

        protected override void OnFinish(TextWriter writer)
        {
            // Add the feedback icon
            if (Icon != Icon.None)
            {
                Config.Icon(Icon).AddCss(Css.FormControlFeedback).Component.StartAndFinish(writer);
            }

            base.OnFinish(writer);
        }

        protected override bool OutputEndTag
        {
            get { return false; }
        }
    }
}
