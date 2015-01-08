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

        public static ComponentBuilder<Container> Container<TComponent>(this IComponentCreator<TComponent> creator)
            where TComponent : Component, ICanCreate<Container>
        {
            return new ComponentBuilder<Container>(creator.Helper, new Container(creator));
        }

        public static ComponentBuilder<Container> SetFluid(this ComponentBuilder<Container> builder, bool fluid = true)
        {
            builder.Component.CssClasses.Remove(Css.Container);
            builder.Component.CssClasses.Remove(Css.ContainerFluid);
            builder.Component.CssClasses.Add(fluid ? Css.ContainerFluid : Css.Container);
            return builder;
        }

        // GridRow

        public static ComponentBuilder<GridRow> GridRow<TComponent>(this IComponentCreator<TComponent> creator)
            where TComponent : Component, ICanCreate<GridRow>
        {
            return new ComponentBuilder<GridRow>(creator.Helper, new GridRow(creator));
        }

        // GridColumn

        public static ComponentBuilder<GridColumn> GridColumn<TComponent>(this IComponentCreator<TComponent> creator, int? md = null)
            where TComponent : Component, ICanCreate<GridColumn>
        {
            return new ComponentBuilder<GridColumn>(creator.Helper, new GridColumn(creator))
                .SetMd(md);
        }
    }
}
