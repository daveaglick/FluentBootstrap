using FluentBootstrap.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentBootstrap
{
    public static class HtmlHelperExtensions
    {
        public static MvcBootstrapHelper<TModel> Bootstrap<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            return new MvcBootstrapHelper<TModel>(htmlHelper);
        }

        // This allows getting a BootstrapHelper given a weakly-typed HtmlHelper (you must specify a model, even if it's just a new object)
        // It can also be used to get a BootstrapHelper for a type that's different than the model (I.e., extra forms on the page)
        // Adapted from an answer to http://stackoverflow.com/questions/1321254/asp-net-mvc-typesafe-html-textboxfor-with-different-outpuTHelper
        public static MvcBootstrapHelper<TModel> Bootstrap<TModel>(this HtmlHelper htmlHelper, TModel model)
        {
            // Create a dummy controller context if we need one (this might happen with RazorGenerator/RazorDatabase)
            ControllerContext controllerContext = htmlHelper.ViewContext.Controller.ControllerContext 
                ?? new ControllerContext(htmlHelper.ViewContext.HttpContext, htmlHelper.ViewContext.RouteData, htmlHelper.ViewContext.Controller);

            ViewContext newViewContext = new ViewContext(
                controllerContext,
                htmlHelper.ViewContext.View,
                new ViewDataDictionary(htmlHelper.ViewDataContainer.ViewData) { Model = model },
                htmlHelper.ViewContext.TempData,
                htmlHelper.ViewContext.Writer);
            var viewDataContainer = new ProxyViewDataContainer(htmlHelper.ViewDataContainer, newViewContext.ViewData);
            return new MvcBootstrapHelper<TModel>(new HtmlHelper<TModel>(newViewContext, viewDataContainer, htmlHelper.RouteCollection));
        }

        internal class ProxyViewDataContainer : IViewDataContainer
        {
            public IViewDataContainer ViewDataContainer { get; private set; }
            public ViewDataDictionary ViewData { get; set; }

            public ProxyViewDataContainer(IViewDataContainer viewDataContainer, ViewDataDictionary viewData)
            {
                ViewDataContainer = viewDataContainer;
                ViewData = viewData;
            }
        }
    }
}
