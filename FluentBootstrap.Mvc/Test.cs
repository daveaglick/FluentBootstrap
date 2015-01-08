using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentBootstrap.Mvc
{
    public static class Test
    {
        public static void Testing()
        {
            MvcBootstrapHelper<object> helper = new MvcBootstrapHelper<object>(new HtmlHelper<object>(null, null, null));
            var validation = helper.ValidationSummary(false);
            validation.Begin().ValidationSummary(false);
            validation.Begin().HelpBlock();
        }
    }
}
