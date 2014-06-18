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

        public static Container<TModel> Container<TModel>(this Container<TModel>.ICreate creator)
        {
            return new Container<TModel>(creator.GetHelper());
        }

        public static Container<TModel> Fluid<TModel>(this Container<TModel> container, bool fluid = true)
        {
            container.CssClasses.Remove("container");
            container.CssClasses.Remove("container-fluid");
            container.CssClasses.Add(fluid ? "container-fluid" : "container");
            return container;
        }

        // GridRow

        public static GridRow<TModel> GridRow<TModel>(this GridRow<TModel>.ICreate creator)
        {
            return new GridRow<TModel>(creator.GetHelper());
        }

        // GridColumn

        public static GridColumn<TModel> GridColumn<TModel>(this GridColumn<TModel>.ICreate creator, int? md = null)
        {
            return new GridColumn<TModel>(creator.GetHelper()).Md(md);
        }
    }
}
