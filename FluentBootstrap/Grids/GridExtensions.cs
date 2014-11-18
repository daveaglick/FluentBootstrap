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

        public static Container<THelper> Container<THelper>(this IContainerCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new Container<THelper>(creator);
        }

        public static Container<THelper> SetFluid<THelper>(this Container<THelper> container, bool fluid = true)
            where THelper : BootstrapHelper<THelper>
        {
            container.CssClasses.Remove(Css.Container);
            container.CssClasses.Remove(Css.ContainerFluid);
            container.CssClasses.Add(fluid ? Css.ContainerFluid : Css.Container);
            return container;
        }

        // GridRow

        public static GridRow<THelper> GridRow<THelper>(this IGridRowCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new GridRow<THelper>(creator);
        }

        // GridColumn

        public static GridColumn<THelper> GridColumn<THelper>(this IGridColumnCreator<THelper> creator, int? md = null)
            where THelper : BootstrapHelper<THelper>
        {
            return new GridColumn<THelper>(creator).SetMd(md);
        }
    }
}
