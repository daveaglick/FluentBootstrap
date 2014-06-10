using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentBootstrap
{
    public class BootstrapHelper
    {
        internal HtmlHelper HtmlHelper { get; private set; }

        internal BootstrapHelper(HtmlHelper htmlHelper)
        {
            HtmlHelper = htmlHelper;
        }
    }

    public class BootstrapHelper<TModel> : BootstrapHelper
    {
        internal HtmlHelper<TModel> StrongHtmlHelper { get; private set; }

        internal BootstrapHelper(HtmlHelper<TModel> htmlHelper)
            : base(htmlHelper)
        {
            StrongHtmlHelper = htmlHelper;
        }
    }
}
