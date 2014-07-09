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
            return new Table<TModel>(creator.GetHelper());
        }

        public static Table<TModel> Striped<TModel>(this Table<TModel> table, bool striped = true)
        {
            table.ToggleCss(Css.TableStriped, striped);
            return table;
        }

        public static Table<TModel> Bordered<TModel>(this Table<TModel> table, bool bordered = true)
        {
            table.ToggleCss(Css.TableBordered, bordered);
            return table;
        }

        public static Table<TModel> Hover<TModel>(this Table<TModel> table, bool hover = true)
        {
            table.ToggleCss(Css.TableHover, hover);
            return table;
        }

        public static Table<TModel> Condensed<TModel>(this Table<TModel> table, bool condensed = true)
        {
            table.ToggleCss(Css.TableCondensed, condensed);
            return table;
        }

        public static Table<TModel> Responsive<TModel>(this Table<TModel> table, bool responsive = true)
        {
            table.Responsive = responsive;
            return table;
        }

        // Sections

        public static TableHead<TModel> TableHead<TModel>(this ITableSectionCreator<TModel> creator)
        {
            return new TableHead<TModel>(creator.GetHelper());
        }

        public static TableBody<TModel> TableBody<TModel>(this ITableSectionCreator<TModel> creator)
        {
            return new TableBody<TModel>(creator.GetHelper());
        }

        public static TableFoot<TModel> TableFoot<TModel>(this ITableSectionCreator<TModel> creator)
        {
            return new TableFoot<TModel>(creator.GetHelper());
        }

        // TableRow

        public static TableRow<TModel> TableRow<TModel>(this ITableRowCreator<TModel> creator)
        {
            return new TableRow<TModel>(creator.GetHelper());
        }

        // Cells

        public static TableHeading<TModel> TableHeading<TModel>(this ITableCellCreator<TModel> creator, object content = null)
        {
            return new TableHeading<TModel>(creator.GetHelper()).AddContent(content);
        }

        public static TableData<TModel> TableData<TModel>(this ITableCellCreator<TModel> creator, object content = null)
        {
            return new TableData<TModel>(creator.GetHelper()).AddContent(content);
        }

        public static TableRow<TModel> TableHeadingRow<TModel>(this ITableCellCreator<TModel> creator, params object[] content)
        {
            TableRow<TModel> row = new TableRow<TModel>(creator.GetHelper()) { HeadRow = true };
            foreach (object c in content)
            {
                row.AddChild(new TableHeading<TModel>(creator.GetHelper()).AddContent(c));
            }
            return row;
        }

        public static TableRow<TModel> TableDataRow<TModel>(this ITableCellCreator<TModel> creator, params object[] content)
        {
            TableRow<TModel> row = new TableRow<TModel>(creator.GetHelper());
            foreach (object c in content)
            {
                row.AddChild(new TableData<TModel>(creator.GetHelper()).AddContent(c));
            }
            return row;
        }

        // IHasTableContextExtensions

        public static TThis Active<TModel, TThis>(this Component<TModel, TThis> component, bool active = true)
            where TThis : Tag<TModel, TThis>, IHasTableContextExtensions
        {
            return SetClass(component, Css.Active, active);
        }

        public static TThis Success<TModel, TThis>(this Component<TModel, TThis> component, bool success = true)
            where TThis : Tag<TModel, TThis>, IHasTableContextExtensions
        {
            return SetClass(component, Css.Success, success);
        }

        public static TThis Warning<TModel, TThis>(this Component<TModel, TThis> component, bool warning = true)
            where TThis : Tag<TModel, TThis>, IHasTableContextExtensions
        {
            return SetClass(component, Css.Warning, warning);
        }

        public static TThis Danger<TModel, TThis>(this Component<TModel, TThis> component, bool danger = true)
            where TThis : Tag<TModel, TThis>, IHasTableContextExtensions
        {
            return SetClass(component, Css.Danger, danger);
        }

        public static TThis Info<TModel, TThis>(this Component<TModel, TThis> component, bool info = true)
            where TThis : Tag<TModel, TThis>, IHasTableContextExtensions
        {
            return SetClass(component, Css.Info, info);
        }

        private static TThis SetClass<TThis, TModel>(Component<TModel, TThis> component, string cls, bool add)
            where TThis : Tag<TModel, TThis>, IHasTableContextExtensions
        {
            TThis tag = component.GetThis();
            tag.ToggleCss(cls, add, Css.Active, Css.Success, Css.Warning, Css.Danger, Css.Info);
            return tag;
        }

        // TableCell

        public static TThis ColSpan<TModel, TThis>(this Component<TModel, TThis> component, int? colSpan)
            where TThis : TableCell<TModel, TThis>
        {
            TThis cell = component.GetThis();
            cell.MergeAttribute("colspan", colSpan == null ? null : colSpan.Value.ToString());
            return cell;
        }

        public static TThis RowSpan<TModel, TThis>(this Component<TModel, TThis> component, int? rowSpan)
            where TThis : TableCell<TModel, TThis>
        {
            TThis cell = component.GetThis();
            cell.MergeAttribute("rowspan", rowSpan == null ? null : rowSpan.Value.ToString());
            return cell;
        }
    }
}
