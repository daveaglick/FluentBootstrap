using System.IO;

namespace FluentBootstrap.Tables
{
    public class TableData : TableCell
    {
        internal TableData(BootstrapHelper helper)
            : base(helper, "td")
        {
        }
        
        protected override void OnStart(TextWriter writer)
        {
            // Only add implicit components if we're in a table
            if (GetComponent<Table>() != null)
            {
                // If we're in a head section, exit out
                Pop<TableHeadSection>(writer);

                // Make sure we're in a row
                if (GetComponent<TableRow>() == null)
                {
                    GetHelper().TableRow().Component.Start(writer);
                }
            }

            base.OnStart(writer);
        }
    }
}