using System;
using System.Collections.Generic;
using System.IO;
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

        // Sections

        public static TableHead TableHead(this BootstrapHelper helper)
        {
            return new TableHead(helper);
        }

        public static TableHead Head(this ComponentWrapper<Table> table)
        {
            return new TableHead(table.Component.Helper);
        }

        public static TableBody TableBody(this BootstrapHelper helper)
        {
            return new TableBody(helper);
        }

        public static TableBody Body(this ComponentWrapper<Table> table)
        {
            return new TableBody(table.Component.Helper);
        }

        public static TableFoot TableFoot(this BootstrapHelper helper)
        {
            return new TableFoot(helper);
        }

        public static TableFoot Foot(this ComponentWrapper<Table> table)
        {
            return new TableFoot(table.Component.Helper);
        }

        // Row

        public static TableRow TableRow(this BootstrapHelper helper)
        {
            return new TableRow(helper);
        }

        public static TableRow Row(this ComponentWrapper<Table> table)
        {
            return new TableRow(table.Component.Helper);
        }

        public static TableRow Row<TSection>(this ComponentWrapper<TSection> tableSection)
            where TSection : TableSection
        {
            return new TableRow(tableSection.Component.Helper);
        }

        // Cells

        public static TableHeading TableHeading(this BootstrapHelper helper, object content = null)
        {
            return new TableHeading(helper).Content(content);
        }

        public static TableHeading Heading(this ComponentWrapper<Table> table, object content = null)
        {
            return new TableHeading(table.Component.Helper).Content(content);
        }

        public static TableHeading Heading(this ComponentWrapper<TableRow> row, object content = null)
        {
            return new TableHeading(row.Component.Helper).Content(content);
        }

        public static TableData TableData(this BootstrapHelper helper, object content = null)
        {
            return new TableData(helper).Content(content);
        }

        public static TableData Data(this ComponentWrapper<Table> table, object content = null)
        {
            return new TableData(table.Component.Helper).Content(content);
        }

        public static TableData Data(this ComponentWrapper<TableRow> row, object content = null)
        {
            return new TableData(row.Component.Helper).Content(content);
        }

        // ITableContext

        public static TComponent Active<TComponent>(this TComponent component, bool active = true)
            where TComponent : Tag, ITableContext
        {
            return SetClass(component, "active", active);
        }

        public static TComponent Success<TComponent>(this TComponent component, bool success = true)
            where TComponent : Tag, ITableContext
        {
            return SetClass(component, "success", success);
        }

        public static TComponent Warning<TComponent>(this TComponent component, bool warning = true)
            where TComponent : Tag, ITableContext
        {
            return SetClass(component, "warning", warning);
        }

        public static TComponent Danger<TComponent>(this TComponent component, bool danger = true)
            where TComponent : Tag, ITableContext
        {
            return SetClass(component, "danger", danger);
        }

        public static TComponent Info<TComponent>(this TComponent component, bool info = true)
            where TComponent : Tag, ITableContext
        {
            return SetClass(component, "info", info);
        }

        private static TComponent SetClass<TComponent>(TComponent component, string cls, bool add)
            where TComponent : Tag, ITableContext
        {
            component.ToggleCssClass(cls, add, "active", "success", "warning", "danger", "info");
            return component;
        }

        // TableCell

        public static TComponent ColSpan<TComponent>(this TComponent component, int? colSpan)
            where TComponent : TableCell
        {
            component.MergeAttribute("colspan", colSpan == null ? null : colSpan.Value.ToString());
            return component;
        }

        public static TComponent RowSpan<TComponent>(this TComponent component, int? rowSpan)
            where TComponent : TableCell
        {
            component.MergeAttribute("rowspan", rowSpan == null ? null : rowSpan.Value.ToString());
            return component;
        }
    }
}
