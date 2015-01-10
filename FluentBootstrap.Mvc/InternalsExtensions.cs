using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FluentBootstrap.Internals;

namespace FluentBootstrap.Mvc.Internals
{
    public static class InternalsExtensions
    {
        // Convenience methods - these just cast, so make sure they're only used from BootstrapHelpers that are actually MvcBootstrapHelpers

        internal static HtmlHelper<TModel> GetHtmlHelper<TModel>(this Component component)
        {
            return ((MvcBootstrapConfig<TModel>)component.Config).HtmlHelper;
        }

        internal static MvcBootstrapHelper<TModel> GetHelper<TModel>(this Component component)
        {
            return new MvcBootstrapHelper<TModel>(component.GetHtmlHelper<TModel>());
        }

        internal static HtmlHelper<TModel> GetHtmlHelper<TModel>(this ComponentOverride componentOverride)
        {
            return ((MvcBootstrapConfig<TModel>)componentOverride.Config).HtmlHelper;
        }

        internal static MvcBootstrapHelper<TModel> GetHelper<TModel>(this ComponentOverride componentOverride)
        {
            return new MvcBootstrapHelper<TModel>(componentOverride.GetHtmlHelper<TModel>());
        }
    }
}
