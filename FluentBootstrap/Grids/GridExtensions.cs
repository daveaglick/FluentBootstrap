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

        public static ComponentBuilder<THelper, Container> Container<THelper, TComponent>(this IComponentCreator<THelper, TComponent> creator)
            where THelper : BootstrapHelper<THelper>
            where TComponent : Component, ICanCreate<Container>
        {
            return new ComponentBuilder<THelper, Container>(creator.Helper, new Container(creator));
        }

        public static ComponentBuilder<THelper, Container> SetFluid<THelper>(this ComponentBuilder<THelper, Container> builder, bool fluid = true)
            where THelper : BootstrapHelper<THelper>
        {
            builder.Component.CssClasses.Remove(Css.Container);
            builder.Component.CssClasses.Remove(Css.ContainerFluid);
            builder.Component.CssClasses.Add(fluid ? Css.ContainerFluid : Css.Container);
            return builder;
        }

        // GridRow

        public static ComponentBuilder<THelper, GridRow> GridRow<THelper, TComponent>(this IComponentCreator<THelper, TComponent> creator)
            where THelper : BootstrapHelper<THelper>
            where TComponent : Component, ICanCreate<GridRow>
        {
            return new ComponentBuilder<THelper, GridRow>(creator.Helper, new GridRow(creator));
        }

        // GridColumn

        public static ComponentBuilder<THelper, GridColumn> GridColumn<THelper, TComponent>(this IComponentCreator<THelper, TComponent> creator, int? md = null)
            where THelper : BootstrapHelper<THelper>
            where TComponent : Component, ICanCreate<GridColumn>
        {
            return new ComponentBuilder<THelper, GridColumn>(creator.Helper, new GridColumn(creator))
                .SetMd(md);
        }
    }
}
