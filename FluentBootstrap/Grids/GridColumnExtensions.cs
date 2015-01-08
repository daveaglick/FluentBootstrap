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
        public static ComponentBuilder<TTag> SetXs<TTag>(this ComponentBuilder<TTag> builder, int? value)
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-xs-", value);
        }

        public static ComponentBuilder<TTag> SetSm<TTag>(this ComponentBuilder<TTag> builder, int? value)
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-sm-", value);
        }

        public static ComponentBuilder<TTag> SetMd<TTag>(this ComponentBuilder<TTag> builder, int? value)
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-md-", value);
        }

        public static ComponentBuilder<TTag> SetLg<TTag>(this ComponentBuilder<TTag> builder, int? value)
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-lg-", value);
        }

        public static ComponentBuilder<TTag> SetXsOffset<TTag>(this ComponentBuilder<TTag> builder, int? value)
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-xs-offset-", value);
        }

        public static ComponentBuilder<TTag> SetSmOffset<TTag>(this ComponentBuilder<TTag> builder, int? value)
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-sm-offset-", value);
        }

        public static ComponentBuilder<TTag> SetMdOffset<TTag>(this ComponentBuilder<TTag> builder, int? value)
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-md-offset-", value);
        }

        public static ComponentBuilder<TTag> SetLgOffset<TTag>(this ComponentBuilder<TTag> builder, int? value)
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-lg-offset-", value);
        }

        public static ComponentBuilder<TTag> SetXsPush<TTag>(this ComponentBuilder<TTag> builder, int? value)
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-xs-push-", value);
        }

        public static ComponentBuilder<TTag> SetSmPush<TTag>(this ComponentBuilder<TTag> builder, int? value)
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-sm-push-", value);
        }

        public static ComponentBuilder<TTag> SetMdPush<TTag>(this ComponentBuilder<TTag> builder, int? value)
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-md-push-", value);
        }

        public static ComponentBuilder<TTag> SetLgPush<TTag>(this ComponentBuilder<TTag> builder, int? value)
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-lg-push-", value);
        }

        public static ComponentBuilder<TTag> SetXsPull<TTag>(this ComponentBuilder<TTag> builder, int? value)
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-xs-pull-", value);
        }

        public static ComponentBuilder<TTag> SetSmPull<TTag>(this ComponentBuilder<TTag> builder, int? value)
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-sm-pull-", value);
        }

        public static ComponentBuilder<TTag> SetMdPull<TTag>(this ComponentBuilder<TTag> builder, int? value)
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-md-pull-", value);
        }

        public static ComponentBuilder<TTag> SetLgPull<TTag>(this ComponentBuilder<TTag> builder, int? value)
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-lg-pull-", value);
        }

        private static ComponentBuilder<TTag> SetColumnClass<TTag>(ComponentBuilder<TTag> builder, string prefix, int? value)
            where TTag : Tag, IHasGridColumnExtensions            
        {
            builder.Component.SetColumnClass(builder.Helper, prefix, value);
            return builder;
        }

        internal static void SetColumnClass(this Tag tag, BootstrapHelper helper, string prefix, int? value)
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
