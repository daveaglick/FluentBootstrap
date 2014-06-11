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

        public static Container Container<TCreator>(this IComponentCreator<TCreator> creator)
            where TCreator : Container.ICreate
        {
            return new Container(creator.GetHelper());
        }

        public static Container Fluid(this Container container, bool fluid = true)
        {
            container.CssClasses.Remove("container");
            container.CssClasses.Remove("container-fluid");
            container.CssClasses.Add(fluid ? "container-fluid" : "container");
            return container;
        }

        // GridRow

        public static GridRow GridRow<TCreator>(this IComponentCreator<TCreator> creator)
            where TCreator : GridRow.ICreate
        {
            return new GridRow(creator.GetHelper());
        }

        // GridColumn

        public static GridColumn GridColumn<TCreator>(this IComponentCreator<TCreator> creator, int? md = null)
            where TCreator : GridColumn.ICreate
        {
            return new GridColumn(creator.GetHelper()).Md(md);
        }
    }
}
