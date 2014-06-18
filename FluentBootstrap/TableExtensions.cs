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

        public static Table Table<TCreator>(this TCreator creator)
            where TCreator : Table.ICreate
        {
            return new Table(creator.GetHelper());
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
        
        public static TableHead TableHead<TCreator>(this TCreator creator)
            where TCreator : TableHead.ICreate
        {
            return new TableHead(creator.GetHelper());
        }

        public static TableBody TableBody<TCreator>(this TCreator creator)
            where TCreator : TableBody.ICreate
        {
            return new TableBody(creator.GetHelper());
        }

        public static TableFoot TableFoot<TCreator>(this TCreator creator)
            where TCreator : TableFoot.ICreate
        {
            return new TableFoot(creator.GetHelper());
        }

        // TableRow

        public static TableRow TableRow<TCreator>(this TCreator creator)
            where TCreator : TableRow.ICreate
        {
            return new TableRow(creator.GetHelper());
        }

        // Cells

        public static TableHeading TableHeading<TCreator>(this TCreator creator, object content = null)
            where TCreator : TableHeading.ICreate
        {
            return new TableHeading(creator.GetHelper()).Content(content);
        }

        public static TableData TableData<TCreator>(this TCreator creator, object content = null)
            where TCreator : TableData.ICreate
        {
            return new TableData(creator.GetHelper()).Content(content);
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
