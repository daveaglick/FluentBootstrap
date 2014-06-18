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
        public static BootstrapHelper<TModel> Bootstrap<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            return new BootstrapHelper<TModel>(htmlHelper);
        }

        // This allows getting a BootstrapHelper given a weakly-typed HtmlHelper (you must specify a model, even if it's just a new object)
        // Adapted from an answer to http://stackoverflow.com/questions/1321254/asp-net-mvc-typesafe-html-textboxfor-with-different-outputmodel
        public static BootstrapHelper<TModel> Bootstrap<TModel>(this HtmlHelper htmlHelper, TModel model)
        {
            ViewContext newViewContext = new ViewContext(
                htmlHelper.ViewContext.Controller.ControllerContext,
                htmlHelper.ViewContext.View,
                new ViewDataDictionary(htmlHelper.ViewDataContainer.ViewData) { Model = model },
                htmlHelper.ViewContext.TempData,
                htmlHelper.ViewContext.Writer);
            var viewDataContainer = new ViewDataContainer(newViewContext.ViewData);
            return new BootstrapHelper<TModel>(new HtmlHelper<TModel>(newViewContext, viewDataContainer, htmlHelper.RouteCollection));
        }

        private class ViewDataContainer : System.Web.Mvc.IViewDataContainer
        {
            public System.Web.Mvc.ViewDataDictionary ViewData { get; set; }

            public ViewDataContainer(System.Web.Mvc.ViewDataDictionary viewData)
            {
                ViewData = viewData;
            }
        }
    }
}
