using FluentBootstrap.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace FluentBootstrap.Mvc.Forms
{
    public interface IValidationSummaryCreator<TModel, THelper> : IComponentCreator<THelper>
        where THelper : MvcBootstrapHelper<TModel>, BootstrapHelper<THelper>
    {
    }

    public class ValidationSummaryWrapper<TModel, THelper> : FormControlWrapper<THelper>
        where THelper : MvcBootstrapHelper<TModel>, BootstrapHelper<THelper>
    {
    }

    internal interface IValidationSummary : IFormControl
    {
    }

    public class ValidationSummary<TModel, THelper> : FormControl<THelper, ValidationSummary<TModel, THelper>, ValidationSummaryWrapper<TModel, THelper>>, IValidationSummary
        where THelper : MvcBootstrapHelper<TModel>, BootstrapHelper<THelper>
    {
        internal bool IncludePropertyErrors { get; set; }

        internal ValidationSummary(IComponentCreator<THelper> creator)
            : base(creator, "div", Css.FormControlStatic, Css.TextDanger)
        {
        }

        protected override void OnStart(System.IO.TextWriter writer)
        {
            base.OnStart(writer);

            // Output the summary
            MvcHtmlString validationSummary = Helper.HtmlHelper.ValidationSummary(!IncludePropertyErrors);
            if (validationSummary != null)
            {
                writer.Write(validationSummary.ToString());
            }

            // Indicate to the form that it's been written
            IForm form = GetComponent<IForm>();
            if (form != null)
            {
                form.GetOverride<FormOverride<TModel>>().HideValidationSummary = true;
            }
        }
    }
}
