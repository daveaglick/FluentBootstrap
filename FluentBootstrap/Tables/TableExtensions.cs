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

        public static Table<THelper> Table<THelper>(this ITableCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new Table<THelper>(creator);
        }

        public static Table<THelper> SetStyle<THelper>(this Table<THelper> table, TableStyle style)
            where THelper : BootstrapHelper<THelper>
        {
            return table.ToggleCss(style);
        }

        public static Table<THelper> SetResponsive<THelper>(this Table<THelper> table, bool responsive = true)
            where THelper : BootstrapHelper<THelper>
        {
            table.Responsive = responsive;
            return table;
        }

        // Sections

        public static TableHeadSection<THelper> TableHeadSection<THelper>(this ITableSectionCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new TableHeadSection<THelper>(creator);
        }

        public static TableBodySection<THelper> TableBodySection<THelper>(this ITableSectionCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new TableBodySection<THelper>(creator);
        }

        public static TableFootSection<THelper> TableFootSection<THelper>(this ITableSectionCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new TableFootSection<THelper>(creator);
        }

        // TableRow

        public static TableRow<THelper> TableRow<THelper>(this ITableRowCreator<THelper> creator)
            where THelper : BootstrapHelper<THelper>
        {
            return new TableRow<THelper>(creator);
        }

        // Cells

        public static TableHeader<THelper> TableHeader<THelper>(this ITableCellCreator<THelper> creator, object content = null)
            where THelper : BootstrapHelper<THelper>
        {
            return new TableHeader<THelper>(creator).AddContent(content);
        }

        public static TableData<THelper> TableData<THelper>(this ITableCellCreator<THelper> creator, object content = null)
            where THelper : BootstrapHelper<THelper>
        {
            return new TableData<THelper>(creator).AddContent(content);
        }

        public static TableRow<THelper> TableHeaderRow<THelper>(this ITableCellCreator<THelper> creator, params object[] content)
            where THelper : BootstrapHelper<THelper>
        {
            TableRow<THelper> row = new TableRow<THelper>(creator) { HeadRow = true };
            foreach (object c in content)
            {
                row.AddChild(new TableHeader<THelper>(creator).AddContent(c));
            }
            return row;
        }

        public static TableRow<THelper> TableDataRow<THelper>(this ITableCellCreator<THelper> creator, params object[] content)
            where THelper : BootstrapHelper<THelper>
        {
            TableRow<THelper> row = new TableRow<THelper>(creator);
            foreach (object c in content)
            {
                row.AddChild(new TableData<THelper>(creator).AddContent(c));
            }
            return row;
        }

        // IHasTableStateExtensions

        public static TThis SetState<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, TableState state)
            where THelper : BootstrapHelper<THelper>
            where TThis : Tag<THelper, TThis, TWrapper>, IHasTableStateExtensions
            where TWrapper : TagWrapper<THelper>, new()
        {
            return component.GetThis().ToggleCss(state);
        }

        // TableCell

        public static TThis ColSpan<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, int? colSpan)
            where THelper : BootstrapHelper<THelper>
            where TThis : TableCell<THelper, TThis, TWrapper>
            where TWrapper : TableCellWrapper<THelper>, new()
        {
            return component.GetThis().MergeAttribute("colspan", colSpan == null ? null : colSpan.Value.ToString());
        }

        public static TThis RowSpan<THelper, TThis, TWrapper>(this Component<THelper, TThis, TWrapper> component, int? rowSpan)
            where THelper : BootstrapHelper<THelper>
            where TThis : TableCell<THelper, TThis, TWrapper>
            where TWrapper : TableCellWrapper<THelper>, new()
        {
            return component.GetThis().MergeAttribute("rowspan", rowSpan == null ? null : rowSpan.Value.ToString());
        }
    }
}
