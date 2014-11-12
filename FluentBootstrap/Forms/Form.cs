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
    {
    }

    public class FormWrapper<THelper> : TagWrapper<THelper>,
        IFieldSetCreator<THelper>,
        IFormGroupCreator<THelper>,
        IControlLabelCreator<THelper>,
        IFormControlCreator<THelper>,
        IHelpBlockCreator<THelper>,
        IInputGroupCreator<THelper>
    {
    }

    internal interface IForm : ITag
    {
        int DefaultLabelWidth { get; }
        bool Horizontal { get; }
        bool HideValidationSummary { set; }
    }

    public abstract class Form<THelper, TThis, TWrapper> : Tag<THelper, TThis, TWrapper>, IForm
        where TThis : Form<THelper, TThis, TWrapper>
        where TWrapper : FormWrapper<THelper>, new()
    {        
        internal int DefaultLabelWidth { get; set; }    // This is only used for horizontal forms

        int IForm.DefaultLabelWidth
        {
            get { return DefaultLabelWidth; }
        }

        internal bool HideValidationSummary { get; set; }

        bool IForm.HideValidationSummary
        {
            set { HideValidationSummary = value; }
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

        protected override void OnStart(TextWriter writer)
        {
            // Generate the form ID if one is needed (if one was already set in the htmlAttributes, this does nothing)
            bool flag = ViewContext.ClientValidationEnabled
                && !ViewContext.UnobtrusiveJavaScriptEnabled;
            if (flag)
            {
                TagBuilder.GenerateId(FormIdGenerator());
            }

            base.OnStart(writer);

            // Set a new form context, including a form ID if one was generated
            ViewContext.FormContext = new FormContext();
            if (flag)
            {
                ViewContext.FormContext.FormId = TagBuilder.Attributes["id"];
            }
        }

        protected override void OnFinish(TextWriter writer)
        {
            // Validation summary if it's not hidden or one was not already output
            if (!HideValidationSummary)
            {
                new ValidationSummary<THelper>(Helper).StartAndFinish(writer);
            }

            base.OnFinish(writer);

            // Intercept the client validation (if there is any) and output on our own writer
            TextWriter viewWriter = ViewContext.Writer;
            ViewContext.Writer = writer;
            ViewContext.OutputClientValidation();
            ViewContext.Writer = viewWriter;

            // Clear the form context
            ViewContext.FormContext = null;
        }

        private readonly static object _lastBootstrapFormNumKey = new object();

        // Get and increment a form id
        private string FormIdGenerator()
        {
            IDictionary items = ViewContext.HttpContext.Items;
            object item = items[_lastBootstrapFormNumKey];
            int num = (item != null ? (int)item + 1 : 0);
            items[_lastBootstrapFormNumKey] = num;
            return string.Format("bsform{0}", num);
        }
    }
    
    public class Form<THelper> : Form<THelper, Form<THelper>, FormWrapper<THelper>>, IForm
    {
        public Form(IComponentCreator<THelper> creator) : base(creator)
        {
        }
    }
}
