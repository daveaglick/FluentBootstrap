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

        public static ComponentBuilder<TConfig, Table> Table<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Table>
        {
            return new ComponentBuilder<TConfig, Table>(helper.Config, new Table(helper));
        }

        public static ComponentBuilder<TConfig, Table> SetStyle<TConfig>(this ComponentBuilder<TConfig, Table> builder, TableStyle style)
            where TConfig : BootstrapConfig
        {
            builder.Component.ToggleCss(style);
            return builder;
        }

        public static ComponentBuilder<TConfig, Table> SetResponsive<TConfig>(this ComponentBuilder<TConfig, Table> builder, bool responsive = true)
            where TConfig : BootstrapConfig
        {
            builder.Component.Responsive = responsive;
            return builder;
        }

        // Sections

        public static ComponentBuilder<TConfig, TableHeadSection> TableHeadSection<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<TableHeadSection>
        {
            return new ComponentBuilder<TConfig, TableHeadSection>(helper.Config, new TableHeadSection(helper));
        }

        public static ComponentBuilder<TConfig, TableBodySection> TableBodySection<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<TableBodySection>
        {
            return new ComponentBuilder<TConfig, TableBodySection>(helper.Config, new TableBodySection(helper));
        }

        public static ComponentBuilder<TConfig, TableFootSection> TableFootSection<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<TableFootSection>
        {
            return new ComponentBuilder<TConfig, TableFootSection>(helper.Config, new TableFootSection(helper));
        }

        // TableRow

        public static ComponentBuilder<TConfig, TableRow> TableRow<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<TableRow>
        {
            return new ComponentBuilder<TConfig, TableRow>(helper.Config, new TableRow(helper));
        }

        // Cells

        public static ComponentBuilder<TConfig, TableHeader> TableHeader<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, object content = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<TableHeader>
        {
            return new ComponentBuilder<TConfig, TableHeader>(helper.Config, new TableHeader(helper))
                .AddContent(content);
        }

        public static ComponentBuilder<TConfig, TableData> TableData<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, object content = null)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<TableData>
        {
            return new ComponentBuilder<TConfig, TableData>(helper.Config, new TableData(helper))
                .AddContent(content);
        }

        public static ComponentBuilder<TConfig, TableRow> TableHeaderRow<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, params object[] content)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<TableRow>
        {
            ComponentBuilder<TConfig, TableRow> builder = new ComponentBuilder<TConfig, TableRow>(helper.Config, new TableRow(helper) { HeadRow = true });
            foreach (object c in content)
            {
                builder.AddChild(x => x.TableHeader().AddContent(c));
            }
            return builder;
        }

        public static ComponentBuilder<TConfig, TableRow> TableDataRow<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, params object[] content)
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<TableRow>
        {
            ComponentBuilder<TConfig, TableRow> builder = new ComponentBuilder<TConfig, TableRow>(helper.Config, new TableRow(helper));
            foreach (object c in content)
            {
                builder.AddChild(x => x.TableData().AddContent(c));
            }
            return builder;
        }

        // IHasTableStateExtensions

        public static ComponentBuilder<TConfig, TTag> SetState<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, TableState state)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasTableStateExtensions
        {
            builder.Component.ToggleCss(state);
            return builder;
        }

        // TableCell

        public static ComponentBuilder<TConfig, TTableCell> ColSpan<TConfig, TTableCell>(this ComponentBuilder<TConfig, TTableCell> builder, int? colSpan)
            where TConfig : BootstrapConfig
            where TTableCell : TableCell
        {
            builder.Component.MergeAttribute("colspan", colSpan == null ? null : colSpan.Value.ToString());
            return builder;
        }

        public static ComponentBuilder<TConfig, TTableCell> RowSpan<TConfig, TTableCell>(this ComponentBuilder<TConfig, TTableCell> builder, int? rowSpan)
            where TConfig : BootstrapConfig
            where TTableCell : TableCell
        {
            builder.Component.MergeAttribute("rowspan", rowSpan == null ? null : rowSpan.Value.ToString());
            return builder;
        }
    }
}
