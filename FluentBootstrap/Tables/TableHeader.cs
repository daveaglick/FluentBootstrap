using System.IO;

namespace FluentBootstrap.Tables
{
    public class TableHeader : TableCell
    {
        internal TableHeader(BootstrapHelper helper)
            : base(helper, "th")
        {
        }
        
        protected override void OnStart(TextWriter writer)
        {
            // Make sure we're in a row, but only if we're also in a table
            if (GetComponent<Table>() != null && GetComponent<TableRow>() == null)
            {
                // ...and make sure the row is in a head section
                if (GetComponent<TableSection>() == null)
                {
                    GetHelper().TableHeadSection().Component.Start(writer);
                }
                GetHelper().TableRow().Component.Start(writer);
            }

            base.OnStart(writer);
        }
    }
}