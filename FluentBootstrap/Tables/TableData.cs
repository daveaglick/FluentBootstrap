using System.IO;

namespace FluentBootstrap.Tables
{
    public interface ITableData : ITableCell
    {
    }

    public class TableData<TModel> : TableCell<TModel, TableData<TModel>>, ITableData
    {
        internal TableData(BootstrapHelper<TModel> helper)
            : base(helper, "td")
        {
        }

        protected override void Prepare(TextWriter writer)
        {
            base.Prepare(writer);

            // Only add implicit components if we're in a table
            if (GetComponent<Table<TModel>>() != null)
            {
                // If we're in a head section, exit out
                Pop<ITableHead>(writer);

                // Make sure we're in a row
                if (GetComponent<TableRow<TModel>>() == null)
                {
                    new TableRow<TModel>(Helper).Start(writer, true);
                }
            }
        }
    }
}