using System.IO;

namespace FluentBootstrap.Tables
{
    public class TableHeading<TModel> : TableCell<TModel>
    {
        internal TableHeading(BootstrapHelper<TModel> helper)
            : base(helper, "th")
        {
        }

        protected override void Prepare(TextWriter writer)
        {
            base.Prepare(writer);

            // Make sure we're in a row, but only if we're also in a table
            if (GetComponent<Table<TModel>>() != null && GetComponent<TableRow<TModel>>() == null)
            {
                // ...and make sure the row is in a head section
                if (GetComponent<TableSection<TModel>>() == null)
                {
                    new TableHead<TModel>(Helper).Start(writer, true);
                }
                new TableRow<TModel>(Helper).Start(writer, true);
            }
        }
    }
}