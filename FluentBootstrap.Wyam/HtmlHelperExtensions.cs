using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wyam.Modules.Razor;

namespace FluentBootstrap.Wyam
{
    public static class HtmlHelperExtensions
    {
        public static WyamBootstrapHelper Bootstrap(this HtmlHelper htmlHelper)
        {
            return new WyamBootstrapHelper(htmlHelper);
        }
    }
}
