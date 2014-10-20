using System.IO;

namespace FluentBootstrap.Tables
{
    public interface ITableDataCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class TableDataWrapper<TModel> : TableCellWrapper<TModel>
    {
    }

    internal interface ITableData : ITableCell
    {
    }

    public class TableData<TModel> : TableCell<TModel, TableData<TModel>, TableDataWrapper<TModel>>, ITableData
    {
        internal TableData(IComponentCreator<TModel> creator)
            : base(creator, "td")
        {
        }

        protected override void PreStart(TextWriter writer)
        {
            base.PreStart(writer);

            // Only add implicit components if we're in a table
            if (GetComponent<ITable>() != null)
            {
                // If we're in a head section, exit out
                Pop<ITableHeadSection>(writer);

                // Make sure we're in a row
                if (GetComponent<ITableRow>() == null)
                {
                    new TableRow<TModel>(Helper).Start(writer, true);
                }
            }
        }
    }
}