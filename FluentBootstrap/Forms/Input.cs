using FluentBootstrap.Icons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentBootstrap.Forms
{
    internal interface IInput : IFormControl
    {
    }

    public class Input<TModel> : FormControl<TModel, Input<TModel>>, IInput, IHasValueAttribute, IHasNameAttribute
    {
        private Icon _icon = Icon.None;

        internal Icon Icon
        {
            set { _icon = value; }
        }

        internal Input(BootstrapHelper<TModel> helper, FormInputType inputType)
            : base(helper, "input", Css.FormControl)
        {
            MergeAttribute("type", inputType.GetDescription());
        }

        protected override void OnFinish(TextWriter writer)
        {
            // Add the feedback icon
            if (_icon != Icon.None)
            {
                new IconSpan<TModel>(Helper, _icon).AddCss(Css.FormControlFeedback).StartAndFinish(writer);
            }

            base.OnFinish(writer);
        }
    }
}
