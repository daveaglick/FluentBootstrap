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

        public static Table<TModel> Table<TModel>(this ITableCreator<TModel> creator)
        {
            return new Table<TModel>(creator);
        }

        public static Table<TModel> SetStyle<TModel>(this Table<TModel> table, TableStyle style)
        {
            return table.ToggleCss(style);
        }

        public static Table<TModel> SetResponsive<TModel>(this Table<TModel> table, bool responsive = true)
        {
            table.Responsive = responsive;
            return table;
        }

        // Sections

        public static TableHeadSection<TModel> TableHeadSection<TModel>(this ITableSectionCreator<TModel> creator)
        {
            return new TableHeadSection<TModel>(creator);
        }

        public static TableBodySection<TModel> TableBodySection<TModel>(this ITableSectionCreator<TModel> creator)
        {
            return new TableBodySection<TModel>(creator);
        }

        public static TableFootSection<TModel> TableFootSection<TModel>(this ITableSectionCreator<TModel> creator)
        {
            return new TableFootSection<TModel>(creator);
        }

        // TableRow

        public static TableRow<TModel> TableRow<TModel>(this ITableRowCreator<TModel> creator)
        {
            return new TableRow<TModel>(creator);
        }

        // Cells

        public static TableHeader<TModel> TableHeader<TModel>(this ITableCellCreator<TModel> creator, object content = null)
        {
            return new TableHeader<TModel>(creator).AddContent(content);
        }

        public static TableData<TModel> TableData<TModel>(this ITableCellCreator<TModel> creator, object content = null)
        {
            return new TableData<TModel>(creator).AddContent(content);
        }

        public static TableRow<TModel> TableHeaderRow<TModel>(this ITableCellCreator<TModel> creator, params object[] content)
        {
            TableRow<TModel> row = new TableRow<TModel>(creator) { HeadRow = true };
            foreach (object c in content)
            {
                row.AddChild(new TableHeader<TModel>(creator).AddContent(c));
            }
            return row;
        }

        public static TableRow<TModel> TableDataRow<TModel>(this ITableCellCreator<TModel> creator, params object[] content)
        {
            TableRow<TModel> row = new TableRow<TModel>(creator);
            foreach (object c in content)
            {
                row.AddChild(new TableData<TModel>(creator).AddContent(c));
            }
            return row;
        }

        // IHasTableStateExtensions

        public static TThis SetState<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, TableState state)
            where TThis : Tag<TModel, TThis, TWrapper>, IHasTableStateExtensions
            where TWrapper : TagWrapper<TModel>, new()
        {
            return component.GetThis().ToggleCss(state);
        }

        // TableCell

        public static TThis ColSpan<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, int? colSpan)
            where TThis : TableCell<TModel, TThis, TWrapper>
            where TWrapper : TableCellWrapper<TModel>, new()
        {
            return component.GetThis().MergeAttribute("colspan", colSpan == null ? null : colSpan.Value.ToString());
        }

        public static TThis RowSpan<TModel, TThis, TWrapper>(this Component<TModel, TThis, TWrapper> component, int? rowSpan)
            where TThis : TableCell<TModel, TThis, TWrapper>
            where TWrapper : TableCellWrapper<TModel>, new()
        {
            return component.GetThis().MergeAttribute("rowspan", rowSpan == null ? null : rowSpan.Value.ToString());
        }
    }
}
