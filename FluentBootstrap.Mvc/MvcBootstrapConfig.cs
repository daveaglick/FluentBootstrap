using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FluentBootstrap.Forms;
using FluentBootstrap.Mvc.Forms;

namespace FluentBootstrap.Mvc
{
    public class MvcBootstrapConfig<TModel> : BootstrapConfig
    {
        internal HtmlHelper<TModel> HtmlHelper { get; private set; }

        public MvcBootstrapConfig(HtmlHelper<TModel> htmlHelper)
        {
            HtmlHelper = htmlHelper;
        }

        protected override void RegisterComponentOverrides()
        {
            RegisterComponentOverride<Form, FormOverride<TModel>>();
            RegisterComponentOverride<FormControl, FormControlOverride<TModel>>();
        }

        protected override string GetFullHtmlFieldName(string name)
        {
            return HtmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
        }

        protected override TextWriter GetWriter()
        {
            return HtmlHelper.ViewContext.Writer;
        }

        protected override object GetItem(object key, object defaultValue)
        {
            if (HtmlHelper.ViewContext.HttpContext.Items.Contains(key))
            {
                return HtmlHelper.ViewContext.HttpContext.Items[key];
            }
            return defaultValue;
        }

        protected override void AddItem(object key, object value)
        {
            HtmlHelper.ViewContext.HttpContext.Items[key] = value;
        }

    }
}
