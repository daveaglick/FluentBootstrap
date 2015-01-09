using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentBootstrap.Grids;

namespace FluentBootstrap
{
    public static class GridExtensions
    {
        // Container

        public static ComponentBuilder<TConfig, Container> Container<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Container>
        {
            return new ComponentBuilder<TConfig, Container>(helper.Config, new Container(helper));
        }

        public static ComponentBuilder<TConfig, Container> SetFluid<TConfig>(this ComponentBuilder<TConfig, Container> builder, bool fluid = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.CssClasses.Remove(Css.Container);
            builder.Component.CssClasses.Remove(Css.ContainerFluid);
            builder.Component.CssClasses.Add(fluid ? Css.ContainerFluid : Css.Container);
            return builder;
        }

        // GridRow

        public static ComponentBuilder<TConfig, GridRow> GridRow<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<GridRow>
        {
            return new ComponentBuilder<TConfig, GridRow>(helper.Config, new GridRow(helper));
        }

        // GridColumn

        public static ComponentBuilder<TConfig, GridColumn> GridColumn<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, int? md = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<GridColumn>
        {
            return new ComponentBuilder<TConfig, GridColumn>(helper.Config, new GridColumn(helper))
                .SetMd(md);
        }
    }
}
