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
        public static ComponentWrapper<TComponent> Bootstrap<TComponent>(this HtmlHelper htmlHelper, Func<BootstrapHelper, TComponent> componentFunc)
            where TComponent : Component
        {
            BootstrapHelper helper = new BootstrapHelper(htmlHelper);
            TComponent component = componentFunc(helper);
            component.Start(helper.ViewContextWriter);
            return new ComponentWrapper<TComponent>(component);
        }

        public static ComponentWrapper<TComponent> Bootstrap<TModel, TComponent>(this HtmlHelper<TModel> htmlHelper, Func<BootstrapHelper<TModel>, TComponent> componentFunc)
            where TComponent : Component
        {
            BootstrapHelper<TModel> helper = new BootstrapHelper<TModel>(htmlHelper);
            TComponent component = componentFunc(helper);
            component.Start(helper.ViewContextWriter);
            return new ComponentWrapper<TComponent>(component);
        }

        public static ComponentWrapper<TComponent> Bootstrap<TComponent>(this HtmlHelper htmlHelper, TComponent component)
            where TComponent : Component
        {
            BootstrapHelper helper = new BootstrapHelper(htmlHelper);
            component.Start(helper.ViewContextWriter);
            return new ComponentWrapper<TComponent>(component);
        }

        public static ComponentWrapper<TComponent> Bootstrap<TModel, TComponent>(this HtmlHelper<TModel> htmlHelper, TComponent component)
            where TComponent : Component
        {
            BootstrapHelper<TModel> helper = new BootstrapHelper<TModel>(htmlHelper);
            component.Start(helper.ViewContextWriter);
            return new ComponentWrapper<TComponent>(component);
        }

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
