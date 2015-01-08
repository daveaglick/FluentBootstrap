using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentBootstrap.Mvc.Internals
{
    public static class InternalsExtensions
    {
        // Convenience methods - these just cast, so make sure they're only used from BootstrapHelpers that are actually MvcBootstrapHelpers

        internal static MvcBootstrapHelper<TModel> GetHelper<TModel>(this Component component)
        {
            return (MvcBootstrapHelper<TModel>)component.Helper;
        }

        internal static MvcBootstrapHelper<TModel> GetHelper<TModel>(this ComponentOverride componentOverride)
        {
            return (MvcBootstrapHelper<TModel>)componentOverride.Helper;
        }

        internal static HtmlHelper<TModel> GetHtmlHelper<TModel>(this BootstrapHelper helper)
        {
            return ((MvcBootstrapHelper<TModel>)helper).HtmlHelper;
        }
    }
}
