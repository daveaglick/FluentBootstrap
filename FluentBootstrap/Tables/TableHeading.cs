using System.IO;

namespace FluentBootstrap.Tables
{
    public class TableHeading : TableCell
    {
        internal TableHeading(BootstrapHelper helper) : base(helper, "th")
        {
        }

        protected override void Prepare(TextWriter writer)
        {
            base.Prepare(writer);

            // Make sure we're in a row, but only if we're also in a table
            if (GetComponent<Table>() != null && GetComponent<TableRow>() == null)
            {
                // ...and make sure the row is in a head section
                if (GetComponent<TableSection>() == null)
                {
                    new TableHead(Helper).Start(writer, true);
                }
                new TableRow(Helper).Start(writer, true);
            }
        }
    }
}