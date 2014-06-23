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
    public interface IForm : ITag
    {
    }

    public interface IFormCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class Form<TModel> : Tag<TModel, Form<TModel>>, IForm,
        Forms.IFieldSetCreator<TModel>,
        Forms.IFormGroupCreator<TModel>,
        Forms.ILabelCreator<TModel>,
        Forms.IFormControlCreator<TModel>
    {        
        internal int DefaultLabelWidth { get; set; }    // This is only used for horizontal forms
        internal bool HideValidationSummary { get; set; }

        public Form(BootstrapHelper<TModel> helper)
            : base(helper, "form")
        {
            DefaultLabelWidth = Bootstrap.DefaultFormLabelWidth;
        }

        internal bool Horizontal
        {
            get { return CssClasses.Contains("form-horizontal"); }
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

        protected override void PreFinish(TextWriter writer)
        {
            // Validation summary if it's not hidden or one was not already output
            if (!HideValidationSummary)
            {
                new ValidationSummary<TModel>(Helper).StartAndFinish(writer);
            }
        }

        protected override void OnFinish(TextWriter writer)
        {
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
}
