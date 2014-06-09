using FluentBootstrap.Grids;
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
            where TComponent : Tag, IGridColumn
        {
            return SetClass(component, "col-xs-", value);
        }

        public static TComponent Sm<TComponent>(this TComponent component, int? value)
            where TComponent : Tag, IGridColumn
        {
            return SetClass(component, "col-sm-", value);
        }

        public static TComponent Md<TComponent>(this TComponent component, int? value)
            where TComponent : Tag, IGridColumn
        {
            return SetClass(component, "col-md-", value);
        }

        public static TComponent Lg<TComponent>(this TComponent component, int? value)
            where TComponent : Tag, IGridColumn
        {
            return SetClass(component, "col-lg-", value);
        }

        public static TComponent XsOffset<TComponent>(this TComponent component, int? value)
            where TComponent : Tag, IGridColumn
        {
            return SetClass(component, "col-xs-offset-", value);
        }

        public static TComponent SmOffset<TComponent>(this TComponent component, int? value)
            where TComponent : Tag, IGridColumn
        {
            return SetClass(component, "col-sm-offset-", value);
        }

        public static TComponent MdOffset<TComponent>(this TComponent component, int? value)
            where TComponent : Tag, IGridColumn
        {
            return SetClass(component, "col-md-offset-", value);
        }

        public static TComponent LgOffset<TComponent>(this TComponent component, int? value)
            where TComponent : Tag, IGridColumn
        {
            return SetClass(component, "col-lg-offset-", value);
        }

        public static TComponent XsPush<TComponent>(this TComponent component, int? value)
            where TComponent : Tag, IGridColumn
        {
            return SetClass(component, "col-xs-push-", value);
        }

        public static TComponent SmPush<TComponent>(this TComponent component, int? value)
            where TComponent : Tag, IGridColumn
        {
            return SetClass(component, "col-sm-push-", value);
        }

        public static TComponent MdPush<TComponent>(this TComponent component, int? value)
            where TComponent : Tag, IGridColumn
        {
            return SetClass(component, "col-md-push-", value);
        }

        public static TComponent LgPush<TComponent>(this TComponent component, int? value)
            where TComponent : Tag, IGridColumn
        {
            return SetClass(component, "col-lg-push-", value);
        }

        private static TComponent SetClass<TComponent>(TComponent component, string prefix, int? value)
            where TComponent : Tag, IGridColumn
        {
            component.CssClasses.RemoveWhere(x => x.StartsWith(prefix));
            if (value != null && value > 0)
                component.CssClasses.Add(prefix + value.Value);
            return component;
        }
    }
}
