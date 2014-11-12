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
        public static Navbar<MvcBootstrapHelper<TModel>> Navbar<TModel>(this INavbarCreator<MvcBootstrapHelper<TModel>> creator, string brand, string actionName, string controllerName, object routeValues = null, bool fluid = true)
        {
            return creator.Navbar(fluid).AddChild(x => x.Brand(brand, actionName, controllerName, routeValues));
        }

        public static Brand<MvcBootstrapHelper<TModel>> Brand<TModel>(this IBrandCreator<MvcBootstrapHelper<TModel>> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return creator.Brand(text, null).SetAction(actionName, controllerName, routeValues).SetText(text);
        }

        public static NavbarLink<MvcBootstrapHelper<TModel>> NavbarLink<TModel>(this INavbarLinkCreator<MvcBootstrapHelper<TModel>> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return creator.NavbarLink(text, null).SetAction(actionName, controllerName, routeValues).SetText(text);
        }
    }
}
