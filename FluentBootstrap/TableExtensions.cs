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

        public static Table<TModel> Table<TModel>(this Table<TModel>.ICreate creator)
        {
            return new Table<TModel>(creator.GetHelper());
        }

        public static Table<TModel> Striped<TModel>(this Table<TModel> table, bool striped = true)
        {
            table.ToggleCssClass("table-striped", striped);
            return table;
        }

        public static Table<TModel> Bordered<TModel>(this Table<TModel> table, bool bordered = true)
        {
            table.ToggleCssClass("table-bordered", bordered);
            return table;
        }

        public static Table<TModel> Hover<TModel>(this Table<TModel> table, bool hover = true)
        {
            table.ToggleCssClass("table-hover", hover);
            return table;
        }

        public static Table<TModel> Condensed<TModel>(this Table<TModel> table, bool condensed = true)
        {
            table.ToggleCssClass("table-condensed", condensed);
            return table;
        }

        public static Table<TModel> Responsive<TModel>(this Table<TModel> table, bool responsive = true)
        {
            table.Responsive = responsive;
            return table;
        }

        // Sections

        public static TableHead<TModel> TableHead<TModel>(this TableHead<TModel>.ICreate creator)
        {
            return new TableHead<TModel>(creator.GetHelper());
        }

        public static TableBody<TModel> TableBody<TModel>(this TableBody<TModel>.ICreate creator)
        {
            return new TableBody<TModel>(creator.GetHelper());
        }

        public static TableFoot<TModel> TableFoot<TModel>(this TableFoot<TModel>.ICreate creator)
        {
            return new TableFoot<TModel>(creator.GetHelper());
        }

        // TableRow

        public static TableRow<TModel> TableRow<TModel>(this TableRow<TModel>.ICreate creator)
        {
            return new TableRow<TModel>(creator.GetHelper());
        }

        // Cells

        public static TableHeading<TModel> TableHeading<TModel>(this TableHeading<TModel>.ICreate creator, object content = null)
        {
            return new TableHeading<TModel>(creator.GetHelper()).Content<TableHeading<TModel>, TModel>(content);
        }

        public static TableData<TModel> TableData<TModel>(this TableData<TModel>.ICreate creator, object content = null)
        {
            return new TableData<TModel>(creator.GetHelper()).Content<TableData<TModel>, TModel>(content);
        }

        // ITableContext

        public static TComponent Active<TComponent, TModel>(this TComponent component, bool active = true)
            where TComponent : Tag<TModel>, ITableContext
        {
            return SetClass<TComponent, TModel>(component, "active", active);
        }

        public static TComponent Success<TComponent, TModel>(this TComponent component, bool success = true)
            where TComponent : Tag<TModel>, ITableContext
        {
            return SetClass<TComponent, TModel>(component, "success", success);
        }

        public static TComponent Warning<TComponent, TModel>(this TComponent component, bool warning = true)
            where TComponent : Tag<TModel>, ITableContext
        {
            return SetClass<TComponent, TModel>(component, "warning", warning);
        }

        public static TComponent Danger<TComponent, TModel>(this TComponent component, bool danger = true)
            where TComponent : Tag<TModel>, ITableContext
        {
            return SetClass<TComponent, TModel>(component, "danger", danger);
        }

        public static TComponent Info<TComponent, TModel>(this TComponent component, bool info = true)
            where TComponent : Tag<TModel>, ITableContext
        {
            return SetClass<TComponent, TModel>(component, "info", info);
        }

        private static TComponent SetClass<TComponent, TModel>(TComponent component, string cls, bool add)
            where TComponent : Tag<TModel>, ITableContext
        {
            component.ToggleCssClass(cls, add, "active", "success", "warning", "danger", "info");
            return component;
        }

        // TableCell

        public static TComponent ColSpan<TComponent, TModel>(this TComponent component, int? colSpan)
            where TComponent : TableCell<TModel>
        {
            component.MergeAttribute("colspan", colSpan == null ? null : colSpan.Value.ToString());
            return component;
        }

        public static TComponent RowSpan<TComponent, TModel>(this TComponent component, int? rowSpan)
            where TComponent : TableCell<TModel>
        {
            component.MergeAttribute("rowspan", rowSpan == null ? null : rowSpan.Value.ToString());
            return component;
        }
    }
}
