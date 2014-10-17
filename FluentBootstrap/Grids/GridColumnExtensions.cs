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
        public static TThis SetXs<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, int? value)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<TModel>, new()
        {
            return SetColumnClass(component, "col-xs-", value);
        }

        public static TThis SetSm<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, int? value)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<TModel>, new()
        {
            return SetColumnClass(component, "col-sm-", value);
        }

        public static TThis SetMd<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, int? value)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<TModel>, new()
        {
            return SetColumnClass(component, "col-md-", value);
        }

        public static TThis SetLg<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, int? value)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<TModel>, new()
        {
            return SetColumnClass(component, "col-lg-", value);
        }

        public static TThis SetXsOffset<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, int? value)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<TModel>, new()
        {
            return SetColumnClass(component, "col-xs-offset-", value);
        }

        public static TThis SetSmOffset<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, int? value)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<TModel>, new()
        {
            return SetColumnClass(component, "col-sm-offset-", value);
        }

        public static TThis SetMdOffset<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, int? value)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<TModel>, new()
        {
            return SetColumnClass(component, "col-md-offset-", value);
        }

        public static TThis SetLgOffset<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, int? value)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<TModel>, new()
        {
            return SetColumnClass(component, "col-lg-offset-", value);
        }

        public static TThis SetXsPush<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, int? value)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<TModel>, new()
        {
            return SetColumnClass(component, "col-xs-push-", value);
        }

        public static TThis SetSmPush<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, int? value)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<TModel>, new()
        {
            return SetColumnClass(component, "col-sm-push-", value);
        }

        public static TThis SetMdPush<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, int? value)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<TModel>, new()
        {
            return SetColumnClass(component, "col-md-push-", value);
        }

        public static TThis SetLgPush<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, int? value)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<TModel>, new()
        {
            return SetColumnClass(component, "col-lg-push-", value);
        }

        public static TThis SetXsPull<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, int? value)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<TModel>, new()
        {
            return SetColumnClass(component, "col-xs-pull-", value);
        }

        public static TThis SetSmPull<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, int? value)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<TModel>, new()
        {
            return SetColumnClass(component, "col-sm-pull-", value);
        }

        public static TThis SetMdPull<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, int? value)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<TModel>, new()
        {
            return SetColumnClass(component, "col-md-pull-", value);
        }

        public static TThis SetLgPull<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, int? value)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<TModel>, new()
        {
            return SetColumnClass(component, "col-lg-pull-", value);
        }

        private static TThis SetColumnClass<TModel, TThis, TWrapper>(Component<TModel, TThis, TWrapper> component, string prefix, int? value)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<TModel>, new()
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
                if (value < 0)
                {
                    value = 1;
                }
                if (value > Bootstrap.GridColumns)
                {
                    value = Bootstrap.GridColumns;
                }
                tag.CssClasses.Add(prefix + value.Value);
            }
        }
    }
}
