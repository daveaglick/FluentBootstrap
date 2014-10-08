using System.IO;

namespace FluentBootstrap.Tables
{
    internal interface ITableHeader : ITableCell
    {
    }

    public class TableHeader<TModel> : TableCell<TModel, TableHeader<TModel>>, ITableHeader
    {
        internal TableHeader(BootstrapHelper<TModel> helper)
            : base(helper, "th")
        {
        }

        protected override void PreStart(TextWriter writer)
        {
            base.PreStart(writer);

            // Make sure we're in a row, but only if we're also in a table
            if (GetComponent<ITable>() != null && GetComponent<ITableRow>() == null)
            {
                // ...and make sure the row is in a head section
                if (GetComponent<ITableSection>() == null)
                {
                    new TableHeadSection<TModel>(Helper).Start(writer, true);
                }
                new TableRow<TModel>(Helper).Start(writer, true);
            }
        }
    }
}