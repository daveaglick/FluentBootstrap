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
        public static Navbar<THelper> Navbar<THelper>(this INavbarCreator<THelper> creator, string brand, string actionName, string controllerName, object routeValues = null, bool fluid = true)
            where THelper : MvcBootstrapHelper<THelper>, BootstrapHelper<THelper>
        {
            return creator.Navbar(fluid).AddChild(x => x.Brand(brand, actionName, controllerName, routeValues));
        }

        public static Brand<THelper> Brand<THelper>(this IBrandCreator<THelper> creator, string text, string actionName, string controllerName, object routeValues = null)
            where THelper : MvcBootstrapHelper<THelper>, BootstrapHelper<THelper>
        {
            return creator.Brand(text, null).SetAction(actionName, controllerName, routeValues).SetText(text);
        }

        public static NavbarLink<THelper> NavbarLink<THelper>(this INavbarLinkCreator<THelper> creator, string text, string actionName, string controllerName, object routeValues = null)
            where THelper : MvcBootstrapHelper<THelper>, BootstrapHelper<THelper>
        {
            return creator.NavbarLink(text, null).SetAction(actionName, controllerName, routeValues).SetText(text);
        }
    }
}
