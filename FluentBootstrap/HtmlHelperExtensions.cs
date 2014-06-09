using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FluentBootstrap
{
    public static class HtmlHelperExtensions
    {
        public static BootstrapHelper Bootstrap(this HtmlHelper htmlHelper)
        {
            return new BootstrapHelper(htmlHelper);
        }

        public static BootstrapHelper Bootstrap<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            return new BootstrapHelper<TModel>(htmlHelper);
        }
    }
}
