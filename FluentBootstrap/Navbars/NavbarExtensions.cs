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

        public static Navbar<THelper> Navbar<THelper>(this INavbarCreator<THelper> creator, bool fluid = true)
        {
            return new Navbar<THelper>(creator).SetFluid(fluid);
        }

        public static Navbar<THelper> Navbar<THelper>(this INavbarCreator<THelper> creator, string brand, string href="#", bool fluid = true)
        {
            return new Navbar<THelper>(creator).SetFluid(fluid).AddChild(x => x.Brand(brand, href));
        }

        public static Navbar<THelper> SetFluid<THelper>(this Navbar<THelper> navbar, bool fluid = true)
        {
            navbar.Fluid = fluid;
            return navbar;
        }

        public static Navbar<THelper> SetPosition<THelper>(this Navbar<THelper> navbar, NavbarPosition position)
        {
            return navbar.ToggleCss(position);
        }

        public static Navbar<THelper> SetInverse<THelper>(this Navbar<THelper> navbar, bool inverse = true)
        {
            return navbar.ToggleCss(Css.NavbarInverse, inverse);
        }

        // NavbarHeader

        public static NavbarHeader<THelper> NavbarHeader<THelper>(this INavbarHeaderCreator<THelper> creator)
        {
            return new NavbarHeader<THelper>(creator);
        }

        // NavbarToggle

        public static NavbarToggle<THelper> NavbarToggle<THelper>(this INavbarToggleCreator<THelper> creator)
        {
            return new NavbarToggle<THelper>(creator);
        }

        public static NavbarToggle<THelper> SetDataTarget<THelper>(this NavbarToggle<THelper> navbarToggle, string dataTarget)
        {
            navbarToggle.DataTarget = dataTarget;
            return navbarToggle;
        }

        public static NavbarToggle<THelper> SetHamburger<THelper>(this NavbarToggle<THelper> navbarToggle, bool hamburger = true)
        {
            navbarToggle.Hamburger = hamburger;
            return navbarToggle;
        }

        // Brand

        public static Brand<THelper> Brand<THelper>(this IBrandCreator<THelper> creator, string text, string href = "#")
        {
            return new Brand<THelper>(creator).SetHref(href).SetText(text);
        }

        public static Brand<THelper> Brand<THelper>(this IBrandCreator<THelper> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return new Brand<THelper>(creator).SetAction(actionName, controllerName, routeValues).SetText(text);
        }

        // NavbarCollapse

        public static NavbarCollapse<THelper> NavbarCollapse<THelper>(this INavbarCollapseCreator<THelper> creator)
        {
            return new NavbarCollapse<THelper>(creator);
        }

        // NavbarNav

        public static NavbarNav<THelper> NavbarNav<THelper>(this INavbarNavCreator<THelper> creator)
        {
            return new NavbarNav<THelper>(creator);
        }

        // NavbarForm

        public static NavbarForm<THelper> NavbarForm<THelper>(this INavbarFormCreator<THelper> creator)
        {
            return new NavbarForm<THelper>(creator);
        }

        // NavbarButton

        public static NavbarButton<THelper> NavbarButton<THelper>(this INavbarButtonCreator<THelper> creator, string text = null, object value = null)
        {
            return new NavbarButton<THelper>(creator).SetText(text).SetValue(value);
        }

        // NavbarText

        public static NavbarText<THelper> NavbarText<THelper>(this INavbarButtonCreator<THelper> creator, string text = null)
        {
            return new NavbarText<THelper>(creator).SetText(text);
        }        
        
        // NavbarLink

        public static NavbarLink<THelper> NavbarLink<THelper>(this INavbarLinkCreator<THelper> creator, string text, string href = "#")
        {
            return new NavbarLink<THelper>(creator).SetHref(href).SetText(text);
        }

        public static NavbarLink<THelper> NavbarLink<THelper>(this INavbarLinkCreator<THelper> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return new NavbarLink<THelper>(creator).SetAction(actionName, controllerName, routeValues).SetText(text);
        }

        public static NavbarLink<THelper> SetActive<THelper>(this NavbarLink<THelper> navbarLink, bool active = true)
        {
            navbarLink.Active = active;
            return navbarLink;
        }

        public static NavbarLink<THelper> SetDisabled<THelper>(this NavbarLink<THelper> navbarLink, bool disabled = true)
        {
            navbarLink.Disabled = disabled;
            return navbarLink;
        }

        // INavbarComponent

        public static TThis SetLeft<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, bool left = true)
            where TThis : Tag<THelper, TThis, TWrapper>, INavbarComponent
            where TWrapper : TagWrapper<THelper>, new()
        {
            return component.GetThis().ToggleCss(Css.NavbarLeft, left, Css.NavbarRight);
        }

        public static TThis SetRight<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, bool right = true)
            where TThis : Tag<THelper, TThis, TWrapper>, INavbarComponent
            where TWrapper : TagWrapper<THelper>, new()
        {
            return component.GetThis().ToggleCss(Css.NavbarRight, right, Css.NavbarLeft);
        }
    }
}
