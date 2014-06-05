using FluentBootstrap.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class ColumnExtensions
    {
        public static TComponent Xs<TComponent>(this TComponent component, int? value)
            where TComponent : BootstrapComponent, IColumn
        {
            return SetColumnClass(component, "col-xs-", value);
        }

        public static TComponent Sm<TComponent>(this TComponent component, int? value)
            where TComponent : BootstrapComponent, IColumn
        {
            return SetColumnClass(component, "col-sm-", value);
        }

        public static TComponent Md<TComponent>(this TComponent component, int? value)
            where TComponent : BootstrapComponent, IColumn
        {
            return SetColumnClass(component, "col-md-", value);
        }

        public static TComponent Lg<TComponent>(this TComponent component, int? value)
            where TComponent : BootstrapComponent, IColumn
        {
            return SetColumnClass(component, "col-lg-", value);
        }

        // TODO: Add offset and pulls

        private static TComponent SetColumnClass<TComponent>(TComponent component, string prefix, int? value)
            where TComponent : BootstrapComponent, IColumn
        {
            component.CssClasses.RemoveWhere(x => x.StartsWith(prefix));
            if (value != null)
                component.CssClasses.Add(prefix + value.Value);
            return component;
        }
    }
}
