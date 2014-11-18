using FluentBootstrap.WebPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages;
using System.Web.WebPages.Html;

namespace FluentBootstrap
{
    public static class HtmlHelperExtensions
    {
        public static WebPagesBootstrapHelper Bootstrap(this HtmlHelper htmlHelper, WebPageBase webPageBase)
        {
            return new WebPagesBootstrapHelper(webPageBase);
        }

        public static WebPagesBootstrapHelper Bootstrap(this WebPageBase webPageBase)
        {
            return new WebPagesBootstrapHelper(webPageBase);
        }
    }
}
