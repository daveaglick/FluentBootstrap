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

        public static Pills<TModel> Pills<TModel>(this IPillsCreator<TModel> creator)
        {
            return new Pills<TModel>(creator);
        }

        public static Pills<TModel> SetStacked<TModel>(this Pills<TModel> pills, bool stacked = true)
        {
            return pills.ToggleCss(Css.NavStacked, stacked);
        }

        public static Pill<TModel> Pill<TModel>(this IPillCreator<TModel> creator, string text, string href = "#")
        {
            return new Pill<TModel>(creator).SetHref(href).SetText(text);
        }

        public static Pill<TModel> Pill<TModel>(this IPillCreator<TModel> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return new Pill<TModel>(creator).SetAction(actionName, controllerName, routeValues).SetText(text);
        }

        // Tabs

        public static Tabs<TModel> Tabs<TModel>(this ITabsCreator<TModel> creator)
        {
            return new Tabs<TModel>(creator);
        }

        public static Tab<TModel> Tab<TModel>(this ITabCreator<TModel> creator, string text, string href = "#")
        {
            return new Tab<TModel>(creator).SetHref(href).SetText(text);
        }

        public static Tab<TModel> Tab<TModel>(this ITabCreator<TModel> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return new Tab<TModel>(creator).SetAction(actionName, controllerName, routeValues).SetText(text);
        }

        // Nav/NavLink

        public static TThis SetActive<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, bool active = true)
            where TThis : NavLink<TModel, TThis, TWrapper>
            where TWrapper : NavLinkWrapper<TModel>, new()
        {
            TThis navLink = component.GetThis();
            navLink.Active = active;
            return navLink;
        }

        public static TThis SetDisabled<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, bool disabled = true)
            where TThis : NavLink<TModel, TThis, TWrapper>
            where TWrapper : NavLinkWrapper<TModel>, new()
        {
            TThis navLink = component.GetThis();
            navLink.Disabled = disabled;
            return navLink;
        }

        public static TThis SetJustified<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, bool justified = true)
            where TThis : Nav<TModel, TThis, TWrapper>
            where TWrapper : NavWrapper<TModel>, new()
        {
            return component.GetThis().ToggleCss(Css.NavJustified, justified);
        }
    }
}
