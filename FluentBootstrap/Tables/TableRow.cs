using System.IO;

namespace FluentBootstrap.Tables
{
    public class TableRow : Tag, ITableContext
    {
        internal TableRow(BootstrapHelper helper) : base(helper, "tr")
        {
        }

        protected override void Prepare(TextWriter writer)
        {
            base.Prepare(writer);

            Pop<TableRow>(writer);

            // Make sure we're in a section, but only if we're also in a table
            if (GetComponent<Table>() != null && GetComponent<TableSection>() == null)
            {
                new TableBody(Helper).Start(writer, true);
            }
        }
    }
}