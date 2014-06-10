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

        public static Row GridRow(this BootstrapHelper helper)
        {
            return new Row(helper);
        }

        public static Row Row(this ComponentWrapper<Container> container)
        {
            return new Row(container.Component.Helper);
        }

        // Column
        
        public static Column GridColumn(this BootstrapHelper helper, int? md = null)
        {
            return new Column(helper).Md(md);
        }

        public static Column Column(this ComponentWrapper<Row> row, int? md = null)
        {
            return new Column(row.Component.Helper).Md(md);
        }
    }
}
