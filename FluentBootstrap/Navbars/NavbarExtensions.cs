using FluentBootstrap.Navbars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class NavbarExtensions
    {
        // Navbar

        public static Navbar<TModel> Navbar<TModel>(this INavbarCreator<TModel> creator, bool fluid = true)
        {
            return new Navbar<TModel>(creator).SetFluid(fluid);
        }

        public static Navbar<TModel> SetFluid<TModel>(this Navbar<TModel> navbar, bool fluid = true)
        {
            navbar.Fluid = fluid;
            return navbar;
        }

        // NavbarHeader

        public static NavbarHeader<TModel> NavbarHeader<TModel>(this INavbarHeaderCreator<TModel> creator)
        {
            return new NavbarHeader<TModel>(creator);
        }

        // NavbarToggle

        public static NavbarToggle<TModel> NavbarToggle<TModel>(this INavbarToggleCreator<TModel> creator)
        {
            return new NavbarToggle<TModel>(creator);
        }

        public static NavbarToggle<TModel> SetDataTarget<TModel>(this NavbarToggle<TModel> navbarToggle, string dataTarget)
        {
            navbarToggle.DataTarget = dataTarget;
            return navbarToggle;
        }

        public static NavbarToggle<TModel> SetHamburger<TModel>(this NavbarToggle<TModel> navbarToggle, bool hamburger = true)
        {
            navbarToggle.Hamburger = hamburger;
            return navbarToggle;
        }

        // Brand

        public static Brand<TModel> Brand<TModel>(this IBrandCreator<TModel> creator, string text, string href = "#")
        {
            return new Brand<TModel>(creator).SetHref(href).SetText(text);
        }

        public static Brand<TModel> Brand<TModel>(this IBrandCreator<TModel> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return new Brand<TModel>(creator).SetAction(actionName, controllerName, routeValues).SetText(text);
        }

        // NavbarCollapse

        public static NavbarCollapse<TModel> NavbarCollapse<TModel>(this INavbarCollapseCreator<TModel> creator)
        {
            return new NavbarCollapse<TModel>(creator);
        }

        // NavbarNav

        public static NavbarNav<TModel> NavbarNav<TModel>(this INavbarNavCreator<TModel> creator)
        {
            return new NavbarNav<TModel>(creator);
        }

    }
}
