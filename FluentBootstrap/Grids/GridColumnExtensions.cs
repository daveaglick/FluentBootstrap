using FluentBootstrap.Grids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentBootstrap.Internals;

namespace FluentBootstrap
{
    public static class GridColumnExtensions
    {
        public static TThis SetXs<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, int? value)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<THelper>, new()
        {
            return SetColumnClass(component, "col-xs-", value);
        }

        public static TThis SetSm<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, int? value)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<THelper>, new()
        {
            return SetColumnClass(component, "col-sm-", value);
        }

        public static TThis SetMd<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, int? value)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<THelper>, new()
        {
            return SetColumnClass(component, "col-md-", value);
        }

        public static TThis SetLg<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, int? value)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<THelper>, new()
        {
            return SetColumnClass(component, "col-lg-", value);
        }

        public static TThis SetXsOffset<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, int? value)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<THelper>, new()
        {
            return SetColumnClass(component, "col-xs-offset-", value);
        }

        public static TThis SetSmOffset<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, int? value)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<THelper>, new()
        {
            return SetColumnClass(component, "col-sm-offset-", value);
        }

        public static TThis SetMdOffset<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, int? value)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<THelper>, new()
        {
            return SetColumnClass(component, "col-md-offset-", value);
        }

        public static TThis SetLgOffset<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, int? value)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<THelper>, new()
        {
            return SetColumnClass(component, "col-lg-offset-", value);
        }

        public static TThis SetXsPush<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, int? value)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<THelper>, new()
        {
            return SetColumnClass(component, "col-xs-push-", value);
        }

        public static TThis SetSmPush<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, int? value)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<THelper>, new()
        {
            return SetColumnClass(component, "col-sm-push-", value);
        }

        public static TThis SetMdPush<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, int? value)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<THelper>, new()
        {
            return SetColumnClass(component, "col-md-push-", value);
        }

        public static TThis SetLgPush<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, int? value)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<THelper>, new()
        {
            return SetColumnClass(component, "col-lg-push-", value);
        }

        public static TThis SetXsPull<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, int? value)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<THelper>, new()
        {
            return SetColumnClass(component, "col-xs-pull-", value);
        }

        public static TThis SetSmPull<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, int? value)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<THelper>, new()
        {
            return SetColumnClass(component, "col-sm-pull-", value);
        }

        public static TThis SetMdPull<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, int? value)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<THelper>, new()
        {
            return SetColumnClass(component, "col-md-pull-", value);
        }

        public static TThis SetLgPull<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, int? value)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<THelper>, new()
        {
            return SetColumnClass(component, "col-lg-pull-", value);
        }

        private static TThis SetColumnClass<THelper, TThis, TWrapper>(Component<THelper, TThis, TWrapper> component, string prefix, int? value)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasGridColumnExtensions
            where TWrapper : TagWrapper<THelper>, new()
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
