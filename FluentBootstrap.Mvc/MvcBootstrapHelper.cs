using FluentBootstrap.Forms;
using FluentBootstrap.Mvc.Forms;
using System;
using System.Collections.Generic;
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
            : base(new MvcOutputContext(htmlHelper))
        {
            HtmlHelper = htmlHelper;
        }

        protected override void RegisterComponentOverrides()
        {
            RegisterComponentOverride<FormOverride<TModel>>();
        }
    }
}
