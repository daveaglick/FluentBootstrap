using FluentBootstrap.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using FluentBootstrap.Mvc.Internals;

namespace FluentBootstrap.Mvc.Forms
{
    public class ValidationSummary<TModel> : FormControl
    {
        public bool IncludePropertyErrors { get; set; }

        internal ValidationSummary(BootstrapHelper helper)
            : base(helper, "div", Css.FormControlStatic, Css.TextDanger)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);

            // Output the summary
            MvcHtmlString validationSummary = this.GetHtmlHelper<TModel>().ValidationSummary(!IncludePropertyErrors);
            if (validationSummary != null)
            {
                writer.Write(validationSummary.ToString());
            }

            // Indicate to the form that it's been written
            Form form = GetComponent<Form>();
            if (form != null)
            {
                form.GetOverride<FormOverride<TModel>>().HideValidationSummary = true;
            }
        }
    }
}
