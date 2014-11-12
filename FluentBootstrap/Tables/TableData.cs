using System.IO;

namespace FluentBootstrap.Tables
{
    public interface ITableDataCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class TableDataWrapper<THelper> : TableCellWrapper<THelper>
    {
    }

    internal interface ITableData : ITableCell
    {
    }

    public class TableData<THelper> : TableCell<THelper, TableData<THelper>, TableDataWrapper<THelper>>, ITableData
    {
        internal TableData(IComponentCreator<THelper> creator)
            : base(creator, "td")
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
                    new TableRow<THelper>(Helper).Start(writer);
                }
            }

            base.OnStart(writer);
        }
    }
}