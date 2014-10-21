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
        public static Tabs<TModel> Tabs<TModel>(this ITabsCreator<TModel> creator)
        {
            return new Tabs<TModel>(creator);
        }

        public static Pills<TModel> Pills<TModel>(this IPillsCreator<TModel> creator)
        {
            return new Pills<TModel>(creator);
        }

        public static Pills<TModel> SetStacked<TModel>(this Pills<TModel> pills, bool stacked = true)
        {
            return pills.ToggleCss(Css.NavStacked, stacked);
        }

        public static TThis SetJustified<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, bool justified = true)
            where TThis : Nav<TModel, TThis, TWrapper>
            where TWrapper : NavWrapper<TModel>, new()
        {
            return component.GetThis().ToggleCss(Css.NavJustified, justified);
        }

        // NavLink

        public static NavLink<TModel> NavLink<TModel>(this INavLinkCreator<TModel> creator, string text, string href = "#")
        {
            return new NavLink<TModel>(creator).SetHref(href).SetText(text);
        }

        public static NavLink<TModel> NavLink<TModel>(this INavLinkCreator<TModel> creator, string text, string actionName, string controllerName, object routeValues = null)
        {
            return new NavLink<TModel>(creator).SetAction(actionName, controllerName, routeValues).SetText(text);
        }

        public static NavLink<TModel> SetActive<TModel>(this NavLink<TModel> navLink, bool active = true)
        {
            navLink.Active = active;
            return navLink;
        }

        public static NavLink<TModel> SetDisabled<TModel>(this NavLink<TModel> navLink, bool disabled = true)
        {
            navLink.Disabled = disabled;
            return navLink;
        }
    }
}
