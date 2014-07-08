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
        public static TThis Xs<TModel, TThis>(this Component<TModel, TThis> component, int? value)
            where TThis : Tag<TModel, TThis>, IHasGridColumnExtensions
        {
            return SetColumnClass(component, "col-xs-", value);
        }

        public static TThis Sm<TModel, TThis>(this Component<TModel, TThis> component, int? value)
            where TThis : Tag<TModel, TThis>, IHasGridColumnExtensions
        {
            return SetColumnClass(component, "col-sm-", value);
        }

        public static TThis Md<TModel, TThis>(this Component<TModel, TThis> component, int? value)
            where TThis : Tag<TModel, TThis>, IHasGridColumnExtensions
        {
            return SetColumnClass(component, "col-md-", value);
        }

        public static TThis Lg<TModel, TThis>(this Component<TModel, TThis> component, int? value)
            where TThis : Tag<TModel, TThis>, IHasGridColumnExtensions
        {
            return SetColumnClass(component, "col-lg-", value);
        }

        public static TThis XsOffset<TModel, TThis>(this Component<TModel, TThis> component, int? value)
            where TThis : Tag<TModel, TThis>, IHasGridColumnExtensions
        {
            return SetColumnClass(component, "col-xs-offset-", value);
        }

        public static TThis SmOffset<TModel, TThis>(this Component<TModel, TThis> component, int? value)
            where TThis : Tag<TModel, TThis>, IHasGridColumnExtensions
        {
            return SetColumnClass(component, "col-sm-offset-", value);
        }

        public static TThis MdOffset<TModel, TThis>(this Component<TModel, TThis> component, int? value)
            where TThis : Tag<TModel, TThis>, IHasGridColumnExtensions
        {
            return SetColumnClass(component, "col-md-offset-", value);
        }

        public static TThis LgOffset<TModel, TThis>(this Component<TModel, TThis> component, int? value)
            where TThis : Tag<TModel, TThis>, IHasGridColumnExtensions
        {
            return SetColumnClass(component, "col-lg-offset-", value);
        }

        public static TThis XsPush<TModel, TThis>(this Component<TModel, TThis> component, int? value)
            where TThis : Tag<TModel, TThis>, IHasGridColumnExtensions
        {
            return SetColumnClass(component, "col-xs-push-", value);
        }

        public static TThis SmPush<TModel, TThis>(this Component<TModel, TThis> component, int? value)
            where TThis : Tag<TModel, TThis>, IHasGridColumnExtensions
        {
            return SetColumnClass(component, "col-sm-push-", value);
        }

        public static TThis MdPush<TModel, TThis>(this Component<TModel, TThis> component, int? value)
            where TThis : Tag<TModel, TThis>, IHasGridColumnExtensions
        {
            return SetColumnClass(component, "col-md-push-", value);
        }

        public static TThis LgPush<TModel, TThis>(this Component<TModel, TThis> component, int? value)
            where TThis : Tag<TModel, TThis>, IHasGridColumnExtensions
        {
            return SetColumnClass(component, "col-lg-push-", value);
        }

        public static TThis XsPull<TModel, TThis>(this Component<TModel, TThis> component, int? value)
            where TThis : Tag<TModel, TThis>, IHasGridColumnExtensions
        {
            return SetColumnClass(component, "col-xs-pull-", value);
        }

        public static TThis SmPull<TModel, TThis>(this Component<TModel, TThis> component, int? value)
            where TThis : Tag<TModel, TThis>, IHasGridColumnExtensions
        {
            return SetColumnClass(component, "col-sm-pull-", value);
        }

        public static TThis MdPull<TModel, TThis>(this Component<TModel, TThis> component, int? value)
            where TThis : Tag<TModel, TThis>, IHasGridColumnExtensions
        {
            return SetColumnClass(component, "col-md-pull-", value);
        }

        public static TThis LgPull<TModel, TThis>(this Component<TModel, TThis> component, int? value)
            where TThis : Tag<TModel, TThis>, IHasGridColumnExtensions
        {
            return SetColumnClass(component, "col-lg-pull-", value);
        }

        private static TThis SetColumnClass<TModel, TThis>(Component<TModel, TThis> component, string prefix, int? value)
            where TThis : Tag<TModel, TThis>, IHasGridColumnExtensions
        {
            TThis tag = component.GetThis();
            tag.SetColumnClass(prefix, value);
            return tag;
        }

        internal static void SetColumnClass(this ITag tag, string prefix, int? value)
        {
            tag.CssClasses.RemoveWhere(x => x.StartsWith(prefix));
            if (value != null)
            {
                if (value <= 0)
                    value = 1;
                if (value > Bootstrap.GridColumns)
                    value = Bootstrap.GridColumns;
                tag.CssClasses.Add(prefix + value.Value);
            }
        }
    }
}
