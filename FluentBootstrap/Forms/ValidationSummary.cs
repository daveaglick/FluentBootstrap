using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace FluentBootstrap.Forms
{
    public interface IValidationSummaryCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class ValidationSummaryWrapper<THelper> : FormControlWrapper<THelper>
    {
    }

    internal interface IValidationSummary : IFormControl
    {
    }

    public class ValidationSummary<THelper> : FormControl<THelper, ValidationSummary<THelper>, ValidationSummaryWrapper<THelper>>, IValidationSummary
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
                form.HideValidationSummary = true;
            }
        }
    }
}
