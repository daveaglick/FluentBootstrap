using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace FluentBootstrap.Forms
{
    public interface IFormCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class FormWrapper<THelper> : TagWrapper<THelper>,
        IFieldSetCreator<THelper>,
        IFormGroupCreator<THelper>,
        IControlLabelCreator<THelper>,
        IFormControlCreator<THelper>,
        IHelpBlockCreator<THelper>,
        IInputGroupCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface IForm : ITag
    {
        int DefaultLabelWidth { get; }
        bool Horizontal { get; }
    }

    public abstract class Form<THelper, TThis, TWrapper> : Tag<THelper, TThis, TWrapper>, IForm
        where THelper : BootstrapHelper<THelper>
        where TThis : Form<THelper, TThis, TWrapper>
        where TWrapper : FormWrapper<THelper>, new()
    {        
        internal int DefaultLabelWidth { get; set; }    // This is only used for horizontal forms

        int IForm.DefaultLabelWidth
        {
            get { return DefaultLabelWidth; }
        }

        public Form(IComponentCreator<THelper> creator, params string[] cssClasses)
            : base(creator, "form", cssClasses)
        {
            DefaultLabelWidth = Bootstrap.DefaultFormLabelWidth;
            MergeAttribute("role", "form");
        }

        internal bool Horizontal
        {
            get { return CssClasses.Contains(Css.FormHorizontal); }
        }

        bool IForm.Horizontal
        {
            get { return Horizontal; }
        }
    }
    
    public class Form<THelper> : Form<THelper, Form<THelper>, FormWrapper<THelper>>, IForm
        where THelper : BootstrapHelper<THelper>
    {
        public Form(IComponentCreator<THelper> creator) : base(creator)
        {
        }
    }
}
