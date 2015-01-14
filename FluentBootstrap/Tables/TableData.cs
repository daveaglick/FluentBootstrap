using System.IO;

namespace FluentBootstrap.Tables
{
    public interface ITableDataCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class TableDataWrapper<TConfig> : TableCellWrapper<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface ITableData : ITableCell
    {
    }

    public class TableData<TConfig> : TableCell<TConfig, TableData<TConfig>, TableDataWrapper<TConfig>>, ITableData
        where TConfig : BootstrapConfig
    {
        internal TableData(BootstrapHelper helper)
            : base(helper, "td")
        {
        }
        
        protected override void OnStart(TextWriter writer)
        {
            // Only add implicit components if we're in a table
            if (GetComponent<ITable>() != null)
            {
                // If we're in a head section, exit out
                Pop<ITableHeadSection>(writer);

                // Make sure we're in a row
                if (GetComponent<ITableRow>() == null)
                {
                    new TableRow<TConfig>(Helper).Start(writer);
                }
            }

            base.OnStart(writer);
        }
    }
}