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
    public interface IValidationSummaryCreator<TModel> : IComponentCreator<MvcBootstrapHelper<TModel>>
    {
    }

    public class ValidationSummaryWrapper<TModel> : FormControlWrapper<MvcBootstrapHelper<TModel>>
    {
    }

    internal interface IValidationSummary : IFormControl
    {
    }

    public class ValidationSummary<TModel> : FormControl<MvcBootstrapHelper<TModel>, ValidationSummary<TModel>, ValidationSummaryWrapper<TModel>>, IValidationSummary
    {
        internal bool IncludePropertyErrors { get; set; }

        internal ValidationSummary(IComponentCreator<MvcBootstrapHelper<TModel>> creator)
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
