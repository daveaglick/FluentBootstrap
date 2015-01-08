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
        public static ComponentBuilder<THelper, TTag> SetXs<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, int? value)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-xs-", value);
        }

        public static ComponentBuilder<THelper, TTag> SetSm<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, int? value)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-sm-", value);
        }

        public static ComponentBuilder<THelper, TTag> SetMd<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, int? value)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-md-", value);
        }

        public static ComponentBuilder<THelper, TTag> SetLg<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, int? value)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-lg-", value);
        }

        public static ComponentBuilder<THelper, TTag> SetXsOffset<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, int? value)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-xs-offset-", value);
        }

        public static ComponentBuilder<THelper, TTag> SetSmOffset<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, int? value)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-sm-offset-", value);
        }

        public static ComponentBuilder<THelper, TTag> SetMdOffset<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, int? value)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-md-offset-", value);
        }

        public static ComponentBuilder<THelper, TTag> SetLgOffset<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, int? value)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-lg-offset-", value);
        }

        public static ComponentBuilder<THelper, TTag> SetXsPush<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, int? value)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-xs-push-", value);
        }

        public static ComponentBuilder<THelper, TTag> SetSmPush<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, int? value)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-sm-push-", value);
        }

        public static ComponentBuilder<THelper, TTag> SetMdPush<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, int? value)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-md-push-", value);
        }

        public static ComponentBuilder<THelper, TTag> SetLgPush<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, int? value)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-lg-push-", value);
        }

        public static ComponentBuilder<THelper, TTag> SetXsPull<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, int? value)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-xs-pull-", value);
        }

        public static ComponentBuilder<THelper, TTag> SetSmPull<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, int? value)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-sm-pull-", value);
        }

        public static ComponentBuilder<THelper, TTag> SetMdPull<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, int? value)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-md-pull-", value);
        }

        public static ComponentBuilder<THelper, TTag> SetLgPull<THelper, TTag>(this ComponentBuilder<THelper, TTag> builder, int? value)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-lg-pull-", value);
        }

        private static ComponentBuilder<THelper, TTag> SetColumnClass<THelper, TTag>(ComponentBuilder<THelper, TTag> builder, string prefix, int? value)
            where THelper : BootstrapHelper<THelper>
            where TTag : Tag, IHasGridColumnExtensions            
        {
            builder.Component.SetColumnClass(builder.Helper, prefix, value);
            return builder;
        }

        internal static void SetColumnClass<THelper>(this Tag tag, THelper helper, string prefix, int? value)
            where THelper : BootstrapHelper<THelper>
        {
            tag.CssClasses.RemoveWhere(x => x.StartsWith(prefix));
            if (value != null)
            {
                if (value < 0)
                {
                    value = 1;
                }
                if (value > helper.GridColumns)
                {
                    value = helper.GridColumns;
                }
                tag.CssClasses.Add(prefix + value.Value);
            }
        }
    }
}
