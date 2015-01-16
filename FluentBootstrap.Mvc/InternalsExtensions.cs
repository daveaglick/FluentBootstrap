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

        public static HtmlHelper<TModel> GetHtmlHelper<TModel>(this Component component)
        {
            return ((MvcBootstrapConfig<TModel>)component.Config).HtmlHelper;
        }

        public static MvcBootstrapHelper<TModel> GetHelper<TModel>(this Component component)
        {
            return new MvcBootstrapHelper<TModel>(component.GetHtmlHelper<TModel>());
        }

        public static HtmlHelper<TModel> GetHtmlHelper<TModel>(this ComponentOverride componentOverride)
        {
            return ((MvcBootstrapConfig<TModel>)componentOverride.Config).HtmlHelper;
        }

        public static MvcBootstrapHelper<TModel> GetHelper<TModel>(this ComponentOverride componentOverride)
        {
            return new MvcBootstrapHelper<TModel>(componentOverride.GetHtmlHelper<TModel>());
        }

        public static HtmlHelper<TModel> GetHtmlHelper<TModel>(this MvcBootstrapConfig<TModel> config)
        {
            return config.HtmlHelper;
        }
    }
}
