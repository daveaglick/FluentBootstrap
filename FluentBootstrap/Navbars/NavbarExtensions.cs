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
            where THelper : BootstrapHelper<THelper>
        {
            return new Navbar<THelper>(creator).SetFluid(fluid);
        }

        public static Navbar<THelper> Navbar<THelper>(this INavbarCreator<THelper> creator, string brand, string href="/", bool fluid = true)
            where THelper : BootstrapHelper<THelper>
        {
            return new Navbar<THelper>(creator).SetFluid(fluid).AddChild(x => x.Brand(brand, href));
        }

        public static Navbar<THelper> SetFluid<THelper>(this Navbar<THelper> navbar, bool fluid = true)
            where THelper : BootstrapHelper<THelper>
        {
            navbar.Fluid = fluid;
            return navbar;
        }

        public static Navbar<THelper> SetPosition<THelper>(this Navbar<THelper> navbar, NavbarPosition position)
            where THelper : BootstrapHelper<THelper>
        {
            return navbar.ToggleCss(position);
        }

        public static Navbar<THelper> SetInverse<THelper>(this Navbar<THelper> navbar, bool inverse = true)
            where THelper : BootstrapHelper<THelper>
        {
            return navbar.ToggleCss(Css.NavbarInverse, inverse);
        }

        // NavbarHeader

        public static NavbarHeader<THelper> NavbarHeader<THelper>(this INavbarHeaderCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new NavbarHeader<THelper>(creator);
        }

        // NavbarToggle

        public static NavbarToggle<THelper> NavbarToggle<THelper>(this INavbarToggleCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new NavbarToggle<THelper>(creator);
        }

        public static NavbarToggle<THelper> SetDataTarget<THelper>(this NavbarToggle<THelper> navbarToggle, string dataTarget)
            where THelper : BootstrapHelper<THelper>
        {
            navbarToggle.DataTarget = dataTarget;
            return navbarToggle;
        }

        public static NavbarToggle<THelper> SetHamburger<THelper>(this NavbarToggle<THelper> navbarToggle, bool hamburger = true)
            where THelper : BootstrapHelper<THelper>
        {
            navbarToggle.Hamburger = hamburger;
            return navbarToggle;
        }

        // Brand

        public static Brand<THelper> Brand<THelper>(this IBrandCreator<THelper> creator, string text, string href = "#")
            where THelper : BootstrapHelper<THelper>
        {
            return new Brand<THelper>(creator).SetHref(href).SetText(text);
        }

        // NavbarCollapse

        public static NavbarCollapse<THelper> NavbarCollapse<THelper>(this INavbarCollapseCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new NavbarCollapse<THelper>(creator);
        }

        // NavbarNav

        public static NavbarNav<THelper> NavbarNav<THelper>(this INavbarNavCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new NavbarNav<THelper>(creator);
        }

        // NavbarForm

        public static NavbarForm<THelper> NavbarForm<THelper>(this INavbarFormCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new NavbarForm<THelper>(creator);
        }

        // NavbarButton

        public static NavbarButton<THelper> NavbarButton<THelper>(this INavbarButtonCreator<THelper> creator, string text = null, object value = null)
            where THelper : BootstrapHelper<THelper>
        {
            return new NavbarButton<THelper>(creator).SetText(text).SetValue(value);
        }

        // NavbarText

        public static NavbarText<THelper> NavbarText<THelper>(this INavbarButtonCreator<THelper> creator, string text = null)
            where THelper : BootstrapHelper<THelper>
        {
            return new NavbarText<THelper>(creator).SetText(text);
        }        
        
        // NavbarLink

        public static NavbarLink<THelper> NavbarLink<THelper>(this INavbarLinkCreator<THelper> creator, string text, string href = "#")
            where THelper : BootstrapHelper<THelper>
        {
            return new NavbarLink<THelper>(creator).SetHref(href).SetText(text);
        }

        public static NavbarLink<THelper> SetActive<THelper>(this NavbarLink<THelper> navbarLink, bool active = true)
            where THelper : BootstrapHelper<THelper>
        {
            navbarLink.Active = active;
            return navbarLink;
        }

        public static NavbarLink<THelper> SetDisabled<THelper>(this NavbarLink<THelper> navbarLink, bool disabled = true)
            where THelper : BootstrapHelper<THelper>
        {
            navbarLink.Disabled = disabled;
            return navbarLink;
        }

        // INavbarComponent

        public static TThis SetLeft<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, bool left = true)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, INavbarComponent
            where TWrapper : TagWrapper<THelper>, new()
        {
            return component.GetThis().ToggleCss(Css.NavbarLeft, left, Css.NavbarRight);
        }

        public static TThis SetRight<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, bool right = true)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, INavbarComponent
            where TWrapper : TagWrapper<THelper>, new()
        {
            return component.GetThis().ToggleCss(Css.NavbarRight, right, Css.NavbarLeft);
        }
    }
}
