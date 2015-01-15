using FluentBootstrap.Internals;
using FluentBootstrap.Mvc;
using FluentBootstrap.Navbars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class MvcNavbarExtensions
    {
        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Navbar> Navbar<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string brand, string actionName, string controllerName, object routeValues = null, bool fluid = true)
            where TComponent : Component, ICanCreate<Navbar>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, Navbar>(helper.GetConfig(), helper.Navbar(fluid).GetComponent())
                .AddChild(x => x.Brand(brand, actionName, controllerName, routeValues));
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, Brand> Brand<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, string actionName, string controllerName, object routeValues = null)
            where TComponent : Component, ICanCreate<Brand>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, Brand>(helper.GetConfig(), helper.Brand(text, null).GetComponent())
                .SetAction(actionName, controllerName, routeValues)
                .SetText(text);
        }

        public static ComponentBuilder<MvcBootstrapConfig<TModel>, NavbarLink> NavbarLink<TComponent, TModel>(
            this BootstrapHelper<MvcBootstrapConfig<TModel>, TComponent> helper, string text, string actionName, string controllerName, object routeValues = null)
            where TComponent : Component, ICanCreate<NavbarLink>
        {
            return new ComponentBuilder<MvcBootstrapConfig<TModel>, NavbarLink>(helper.GetConfig(), helper.NavbarLink(text, null).GetComponent())
                .SetAction(actionName, controllerName, routeValues)
                .SetText(text);
        }
    }
}
