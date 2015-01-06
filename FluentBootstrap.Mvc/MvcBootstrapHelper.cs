using FluentBootstrap.Forms;
using FluentBootstrap.Mvc.Forms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentBootstrap.Mvc
{
    public class MvcBootstrapHelper<TModel> : BootstrapHelper<MvcBootstrapHelper<TModel>>
    {
        internal HtmlHelper<TModel> HtmlHelper { get; private set; }

        public MvcBootstrapHelper(HtmlHelper<TModel> htmlHelper)
        {
            HtmlHelper = htmlHelper;
        }

        protected override void RegisterComponentOverrides()
        {
            RegisterComponentOverride<IForm, FormOverride<TModel>>((h, c) => new FormOverride<TModel>(h, (IForm)c));
            RegisterComponentOverride<IFormControl, FormControlOverride<TModel>>((h, c) => new FormControlOverride<TModel>(h, (IFormControl)c));
        }

        protected internal override string FormatValue(object value, string format)
        {
            // From ViewDataDictionary.FormatValueInternal(), which is called from HtmlHelper.FormatValue()
            // Reproduced here to remove dependency on ASP.NET MVC 4
            if (value == null)
            {
                return string.Empty;
            }
            if (string.IsNullOrEmpty(format))
            {
                return Convert.ToString(value, CultureInfo.CurrentCulture);
            }
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            object[] objArray = new object[] { value };
            return string.Format(currentCulture, format, objArray);
        }

        protected internal override string GetFullHtmlFieldName(string name)
        {
            return HtmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
        }

        protected internal override TextWriter GetWriter()
        {
            return HtmlHelper.ViewContext.Writer;
        }

        protected internal override object GetItem(object key, object defaultValue)
        {
            if (HtmlHelper.ViewContext.HttpContext.Items.Contains(key))
            {
                return HtmlHelper.ViewContext.HttpContext.Items[key];
            }
            return defaultValue;
        }

        protected internal override void AddItem(object key, object value)
        {
            HtmlHelper.ViewContext.HttpContext.Items[key] = value;
        }
    }
}
