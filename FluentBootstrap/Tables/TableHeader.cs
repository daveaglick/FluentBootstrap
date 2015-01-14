using System.IO;

namespace FluentBootstrap.Tables
{
    public interface ITableHeaderCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class TableHeaderWrapper<TConfig> : TableCellWrapper<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface ITableHeader : ITableCell
    {
    }

    public class TableHeader<TConfig> : TableCell<TConfig, TableHeader<TConfig>, TableHeaderWrapper<TConfig>>, ITableHeader
        where TConfig : BootstrapConfig
    {
        internal TableHeader(BootstrapHelper helper)
            : base(helper, "th")
        {
        }
        
        protected override void OnStart(TextWriter writer)
        {
            // Make sure we're in a row, but only if we're also in a table
            if (GetComponent<ITable>() != null && GetComponent<ITableRow>() == null)
            {
                // ...and make sure the row is in a head section
                if (GetComponent<ITableSection>() == null)
                {
                    new TableHeadSection<TConfig>(Helper).Start(writer);
                }
                new TableRow<TConfig>(Helper).Start(writer);
            }

            base.OnStart(writer);
        }
    }
}