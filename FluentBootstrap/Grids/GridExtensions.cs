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

        public static Container<TModel> Container<TModel>(this IContainerCreator<TModel> creator)
        {
            return new Container<TModel>(creator);
        }

        public static Container<TModel> Fluid<TModel>(this Container<TModel> container, bool fluid = true)
        {
            container.CssClasses.Remove(Css.Container);
            container.CssClasses.Remove(Css.ContainerFluid);
            container.CssClasses.Add(fluid ? Css.ContainerFluid : Css.Container);
            return container;
        }

        // GridRow

        public static GridRow<TModel> GridRow<TModel>(this IGridRowCreator<TModel> creator)
        {
            return new GridRow<TModel>(creator);
        }

        // GridColumn

        public static GridColumn<TModel> GridColumn<TModel>(this IGridColumnCreator<TModel> creator, int? md = null)
        {
            return new GridColumn<TModel>(creator).SetMd(md);
        }
    }
}
