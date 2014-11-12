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
    public interface IInputCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class InputWrapper<THelper> : FormControlWrapper<THelper>
    {
    }

    internal interface IInput : IFormControl
    {
    }

    public class Input<THelper> : FormControl<THelper, Input<THelper>, InputWrapper<THelper>>, IInput, IHasValueAttribute, IHasNameAttribute
    {
        private Icon _icon = Icon.None;

        internal Icon Icon
        {
            set { _icon = value; }
        }

        internal Input(IComponentCreator<THelper> creator, FormInputType inputType)
            : base(creator, "input", Css.FormControl)
        {
            MergeAttribute("type", inputType.GetDescription());
        }

        protected override void OnFinish(TextWriter writer)
        {
            // Add the feedback icon
            if (_icon != Icon.None)
            {
                new IconSpan<THelper>(Helper, _icon).AddCss(Css.FormControlFeedback).StartAndFinish(writer);
            }

            base.OnFinish(writer);
        }

        protected override bool OutputEndTag
        {
            get { return false; }
        }
    }
}
