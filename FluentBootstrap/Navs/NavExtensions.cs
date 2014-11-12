using FluentBootstrap.Navs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class NavExtensions
    {  
        // Pills

        public static Pills<THelper> Pills<THelper>(this IPillsCreator<THelper> creator)
        {
            return new Pills<THelper>(creator);
        }

        public static Pills<THelper> SetStacked<THelper>(this Pills<THelper> pills, bool stacked = true)
        {
            return pills.ToggleCss(Css.NavStacked, stacked);
        }

        public static Pill<THelper> Pill<THelper>(this IPillCreator<THelper> creator, string text, string href = "#")
        {
            return new Pill<THelper>(creator).SetHref(href).SetText(text);
        }

        public static Pill<THelper> Pill<THelper>(this IPillCreator<THelper> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return new Pill<THelper>(creator).SetAction(actionName, controllerName, routeValues).SetText(text);
        }

        // Tabs

        public static Tabs<THelper> Tabs<THelper>(this ITabsCreator<THelper> creator)
        {
            return new Tabs<THelper>(creator);
        }

        public static Tab<THelper> Tab<THelper>(this ITabCreator<THelper> creator, string text, string href = "#")
        {
            return new Tab<THelper>(creator).SetHref(href).SetText(text);
        }

        public static Tab<THelper> Tab<THelper>(this ITabCreator<THelper> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return new Tab<THelper>(creator).SetAction(actionName, controllerName, routeValues).SetText(text);
        }

        // Nav/NavLink

        public static TThis SetActive<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, bool active = true)
            where TThis : NavLink<THelper, TThis, TWrapper>
            where TWrapper : NavLinkWrapper<THelper>, new()
        {
            TThis navLink = component.GetThis();
            navLink.Active = active;
            return navLink;
        }

        public static TThis SetDisabled<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, bool disabled = true)
            where TThis : NavLink<THelper, TThis, TWrapper>
            where TWrapper : NavLinkWrapper<THelper>, new()
        {
            TThis navLink = component.GetThis();
            navLink.Disabled = disabled;
            return navLink;
        }

        public static TThis SetJustified<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, bool justified = true)
            where TThis : Nav<THelper, TThis, TWrapper>
            where TWrapper : NavWrapper<THelper>, new()
        {
            return component.GetThis().ToggleCss(Css.NavJustified, justified);
        }
    }
}
