using FluentBootstrap.Grids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap
{
    public static class GridColumnExtensions
    {
        public static TComponent Xs<TComponent, TModel>(this TComponent component, int? value)
            where TComponent : Tag<TModel>, IGridColumn
        {
            return SetClass<TComponent, TModel>(component, "col-xs-", value);
        }

        public static TComponent Sm<TComponent, TModel>(this TComponent component, int? value)
            where TComponent : Tag<TModel>, IGridColumn
        {
            return SetClass<TComponent, TModel>(component, "col-sm-", value);
        }

        public static TComponent Md<TComponent, TModel>(this TComponent component, int? value)
            where TComponent : Tag<TModel>, IGridColumn
        {
            return SetClass<TComponent, TModel>(component, "col-md-", value);
        }

        public static TComponent Lg<TComponent, TModel>(this TComponent component, int? value)
            where TComponent : Tag<TModel>, IGridColumn
        {
            return SetClass<TComponent, TModel>(component, "col-lg-", value);
        }

        public static TComponent XsOffset<TComponent, TModel>(this TComponent component, int? value)
            where TComponent : Tag<TModel>, IGridColumn
        {
            return SetClass<TComponent, TModel>(component, "col-xs-offset-", value);
        }

        public static TComponent SmOffset<TComponent, TModel>(this TComponent component, int? value)
            where TComponent : Tag<TModel>, IGridColumn
        {
            return SetClass<TComponent, TModel>(component, "col-sm-offset-", value);
        }

        public static TComponent MdOffset<TComponent, TModel>(this TComponent component, int? value)
            where TComponent : Tag<TModel>, IGridColumn
        {
            return SetClass<TComponent, TModel>(component, "col-md-offset-", value);
        }

        public static TComponent LgOffset<TComponent, TModel>(this TComponent component, int? value)
            where TComponent : Tag<TModel>, IGridColumn
        {
            return SetClass<TComponent, TModel>(component, "col-lg-offset-", value);
        }

        public static TComponent XsPush<TComponent, TModel>(this TComponent component, int? value)
            where TComponent : Tag<TModel>, IGridColumn
        {
            return SetClass<TComponent, TModel>(component, "col-xs-push-", value);
        }

        public static TComponent SmPush<TComponent, TModel>(this TComponent component, int? value)
            where TComponent : Tag<TModel>, IGridColumn
        {
            return SetClass<TComponent, TModel>(component, "col-sm-push-", value);
        }

        public static TComponent MdPush<TComponent, TModel>(this TComponent component, int? value)
            where TComponent : Tag<TModel>, IGridColumn
        {
            return SetClass<TComponent, TModel>(component, "col-md-push-", value);
        }

        public static TComponent LgPush<TComponent, TModel>(this TComponent component, int? value)
            where TComponent : Tag<TModel>, IGridColumn
        {
            return SetClass<TComponent, TModel>(component, "col-lg-push-", value);
        }

        private static TComponent SetClass<TComponent, TModel>(TComponent component, string prefix, int? value)
            where TComponent : Tag<TModel>, IGridColumn
        {
            component.CssClasses.RemoveWhere(x => x.StartsWith(prefix));
            if (value != null)
            {
                if (value <= 0)
                    value = 1;
                if (value > Bootstrap.GridColumns)
                    value = Bootstrap.GridColumns;
                component.CssClasses.Add(prefix + value.Value);
            }
            return component;
        }
    }
}
