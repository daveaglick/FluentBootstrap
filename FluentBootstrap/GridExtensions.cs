using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentBootstrap.Grid;

namespace FluentBootstrap
{
    public static class GridExtensions
    {
        // Container

        public static Container Container(this BootstrapHelper helper)
        {
            return new Container(helper);
        }

        public static Container Fluid(this Container container)
        {
            container.CssClasses.Remove("container");
            container.CssClasses.Add("container-fluid");
            return container;
        }

        // Row

        public static Row Row(this BootstrapHelper helper)
        {
            return new Row(helper);
        }

        // Column

        public static Column Column(this BootstrapHelper helper)
        {
            return new Column(helper);
        }

        public static Column Column(this BootstrapHelper helper, int md)
        {
            return (new Column(helper)).Md(md);
        }

        public static Column Column(this ComponentWrapper<Row> row)
        {
            return new Column(row.Component.Helper);
        }

        public static Column Column(this ComponentWrapper<Row> row, int md)
        {
            return (new Column(row.Component.Helper)).Md(md);
        }
    }
}
