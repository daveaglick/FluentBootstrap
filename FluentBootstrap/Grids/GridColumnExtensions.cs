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
        public static ComponentBuilder<TConfig, TTag> SetXs<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, int? value)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-xs-", value);
        }

        public static ComponentBuilder<TConfig, TTag> SetSm<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, int? value)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-sm-", value);
        }

        public static ComponentBuilder<TConfig, TTag> SetMd<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, int? value)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-md-", value);
        }

        public static ComponentBuilder<TConfig, TTag> SetLg<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, int? value)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-lg-", value);
        }

        public static ComponentBuilder<TConfig, TTag> SetXsOffset<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, int? value)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-xs-offset-", value);
        }

        public static ComponentBuilder<TConfig, TTag> SetSmOffset<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, int? value)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-sm-offset-", value);
        }

        public static ComponentBuilder<TConfig, TTag> SetMdOffset<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, int? value)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-md-offset-", value);
        }

        public static ComponentBuilder<TConfig, TTag> SetLgOffset<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, int? value)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-lg-offset-", value);
        }

        public static ComponentBuilder<TConfig, TTag> SetXsPush<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, int? value)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-xs-push-", value);
        }

        public static ComponentBuilder<TConfig, TTag> SetSmPush<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, int? value)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-sm-push-", value);
        }

        public static ComponentBuilder<TConfig, TTag> SetMdPush<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, int? value)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-md-push-", value);
        }

        public static ComponentBuilder<TConfig, TTag> SetLgPush<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, int? value)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-lg-push-", value);
        }

        public static ComponentBuilder<TConfig, TTag> SetXsPull<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, int? value)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-xs-pull-", value);
        }

        public static ComponentBuilder<TConfig, TTag> SetSmPull<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, int? value)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-sm-pull-", value);
        }

        public static ComponentBuilder<TConfig, TTag> SetMdPull<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, int? value)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-md-pull-", value);
        }

        public static ComponentBuilder<TConfig, TTag> SetLgPull<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, int? value)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasGridColumnExtensions            
        {
            return SetColumnClass(builder, "col-lg-pull-", value);
        }

        private static ComponentBuilder<TConfig, TTag> SetColumnClass<TConfig, TTag>(ComponentBuilder<TConfig, TTag> builder, string prefix, int? value)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasGridColumnExtensions            
        {
            builder.Component.SetColumnClass(builder.Config, prefix, value);
            return builder;
        }

        internal static void SetColumnClass(this Tag tag, BootstrapConfig config, string prefix, int? value)
        {
            tag.CssClasses.RemoveWhere(x => x.StartsWith(prefix));
            if (value != null)
            {
                if (value < 0)
                {
                    value = 1;
                }
                if (value > config.GridColumns)
                {
                    value = config.GridColumns;
                }
                tag.CssClasses.Add(prefix + value.Value);
            }
        }
    }
}
