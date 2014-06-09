using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentBootstrap.Tables;

namespace FluentBootstrap
{
    public static class TableExtensions
    {
        // Table

        public static Table Table(this BootstrapHelper helper)
        {
            return new Table(helper);
        }

        public static Table Striped(this Table table, bool striped = true)
        {
            table.ToggleCssClass("table-striped", striped);
            return table;
        }

        public static Table Bordered(this Table table, bool bordered = true)
        {
            table.ToggleCssClass("table-bordered", bordered);
            return table;
        }

        public static Table Hover(this Table table, bool hover = true)
        {
            table.ToggleCssClass("table-hover", hover);
            return table;
        }

        public static Table Condensed(this Table table, bool condensed = true)
        {
            table.ToggleCssClass("table-condensed", condensed);
            return table;
        }

        public static Table Responsive(this Table table, bool responsive = true)
        {
            table.Responsive = responsive;
            return table;
        }
    }
}
