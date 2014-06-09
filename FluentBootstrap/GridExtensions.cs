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

        public static Container Container(this BootstrapHelper helper)
        {
            return new Container(helper);
        }

        public static Container Fluid(this Container container, bool fluid = true)
        {
            container.CssClasses.Remove("container");
            container.CssClasses.Remove("container-fluid");
            container.CssClasses.Add(fluid ? "container-fluid" : "container");
            return container;
        }

        // Row

        public static GridRow GridRow(this BootstrapHelper helper)
        {
            return new GridRow(helper);
        }

        public static GridRow Row(this ComponentWrapper<Container> container)
        {
            return new GridRow(container.Component.Helper);
        }

        // Column
        
        public static GridColumn GridColumn(this BootstrapHelper helper, int? md = null)
        {
            return new GridColumn(helper).Md(md);
        }

        public static GridColumn Column(this ComponentWrapper<GridRow> row, int? md = null)
        {
            return new GridColumn(row.Component.Helper).Md(md);
        }
    }
}
