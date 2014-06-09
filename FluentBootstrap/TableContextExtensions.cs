using FluentBootstrap.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class TableContextExtensions
    {
        public static TComponent Active<TComponent>(this TComponent component, bool active = true)
            where TComponent : Tag, ITableContext
        {
            return SetClass(component, "active", active);
        }

        public static TComponent Success<TComponent>(this TComponent component, bool success = true)
            where TComponent : Tag, ITableContext
        {
            return SetClass(component, "success", success);
        }

        public static TComponent Warning<TComponent>(this TComponent component, bool warning = true)
            where TComponent : Tag, ITableContext
        {
            return SetClass(component, "warning", warning);
        }

        public static TComponent Danger<TComponent>(this TComponent component, bool danger = true)
            where TComponent : Tag, ITableContext
        {
            return SetClass(component, "danger", danger);
        }

        public static TComponent Info<TComponent>(this TComponent component, bool info = true)
            where TComponent : Tag, ITableContext
        {
            return SetClass(component, "info", info);
        }

        private static TComponent SetClass<TComponent>(TComponent component, string cls, bool on)
            where TComponent : Tag, ITableContext
        {
            component.CssClasses.Remove("active");
            component.CssClasses.Remove("success");
            component.CssClasses.Remove("warning");
            component.CssClasses.Remove("danger");
            component.CssClasses.Remove("info");
            if (on)
            {
                component.CssClasses.Add(cls);
            }
            return component;
        }
    }
}
