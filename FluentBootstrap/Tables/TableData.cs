using System.IO;

namespace FluentBootstrap.Tables
{
    public class TableData : TableCell
    {
        public TableData(BootstrapHelper helper) : base(helper, "td")
        {
        }

        protected override void Prepare(TextWriter writer)
        {
            base.Prepare(writer);

            // Only add implicit components if we're in a table
            if (GetComponent<Table>() != null)
            {
                // If we're in a head section, exit out
                Pop<TableHead>(writer);

                // Make sure we're in a row
                if (GetComponent<TableRow>() == null)
                {
                    new TableRow(Helper).Start(writer, true);
                }
            }
        }
    }
}