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

        public static Table<TConfig> Table<TConfig>(this ITableCreator<TConfig> creator)
            where TConfig : BootstrapConfig
        {
            return new Table<TConfig>(creator);
        }

        public static Table<TConfig> SetStyle<TConfig>(this Table<TConfig> table, TableStyle style)
            where TConfig : BootstrapConfig
        {
            return table.ToggleCss(style);
        }

        public static Table<TConfig> SetResponsive<TConfig>(this Table<TConfig> table, bool responsive = true)
            where TConfig : BootstrapConfig
        {
            table.Responsive = responsive;
            return table;
        }

        // Sections

        public static TableHeadSection<TConfig> TableHeadSection<TConfig>(this ITableSectionCreator<TConfig> creator)
            where TConfig : BootstrapConfig
        {
            return new TableHeadSection<TConfig>(creator);
        }

        public static TableBodySection<TConfig> TableBodySection<TConfig>(this ITableSectionCreator<TConfig> creator)
            where TConfig : BootstrapConfig
        {
            return new TableBodySection<TConfig>(creator);
        }

        public static TableFootSection<TConfig> TableFootSection<TConfig>(this ITableSectionCreator<TConfig> creator)
            where TConfig : BootstrapConfig
        {
            return new TableFootSection<TConfig>(creator);
        }

        // TableRow

        public static TableRow<TConfig> TableRow<TConfig>(this ITableRowCreator<TConfig> creator)
            where TConfig : BootstrapConfig
        {
            return new TableRow<TConfig>(creator);
        }

        // Cells

        public static TableHeader<TConfig> TableHeader<TConfig>(this ITableCellCreator<TConfig> creator, object content = null)
            where TConfig : BootstrapConfig
        {
            return new TableHeader<TConfig>(creator).AddContent(content);
        }

        public static TableData<TConfig> TableData<TConfig>(this ITableCellCreator<TConfig> creator, object content = null)
            where TConfig : BootstrapConfig
        {
            return new TableData<TConfig>(creator).AddContent(content);
        }

        public static TableRow<TConfig> TableHeaderRow<TConfig>(this ITableCellCreator<TConfig> creator, params object[] content)
            where TConfig : BootstrapConfig
        {
            TableRow<TConfig> row = new TableRow<TConfig>(creator) { HeadRow = true };
            foreach (object c in content)
            {
                row.AddChild(new TableHeader<TConfig>(creator).AddContent(c));
            }
            return row;
        }

        public static TableRow<TConfig> TableDataRow<TConfig>(this ITableCellCreator<TConfig> creator, params object[] content)
            where TConfig : BootstrapConfig
        {
            TableRow<TConfig> row = new TableRow<TConfig>(creator);
            foreach (object c in content)
            {
                row.AddChild(new TableData<TConfig>(creator).AddContent(c));
            }
            return row;
        }

        // IHasTableStateExtensions

        public static TThis SetState<TConfig, TThis, TWrapper>(this Component<TConfig, TThis, TWrapper> component, TableState state)
            where TConfig : BootstrapConfig
            where TThis : Tag<TConfig, TThis, TWrapper>, IHasTableStateExtensions
            where TWrapper : TagWrapper<TConfig>, new()
        {
            return component.GetThis().ToggleCss(state);
        }

        // TableCell

        public static TThis ColSpan<TConfig, TThis, TWrapper>(this Component<TConfig, TThis, TWrapper> component, int? colSpan)
            where TConfig : BootstrapConfig
            where TThis : TableCell<TConfig, TThis, TWrapper>
            where TWrapper : TableCellWrapper<TConfig>, new()
        {
            return component.GetThis().MergeAttribute("colspan", colSpan == null ? null : colSpan.Value.ToString());
        }

        public static TThis RowSpan<TConfig, TThis, TWrapper>(this Component<TConfig, TThis, TWrapper> component, int? rowSpan)
            where TConfig : BootstrapConfig
            where TThis : TableCell<TConfig, TThis, TWrapper>
            where TWrapper : TableCellWrapper<TConfig>, new()
        {
            return component.GetThis().MergeAttribute("rowspan", rowSpan == null ? null : rowSpan.Value.ToString());
        }
    }
}
