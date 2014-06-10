using System.IO;

namespace FluentBootstrap.Tables
{
    public class Heading : Cell
    {
        internal Heading(BootstrapHelper helper) : base(helper, "th")
        {
        }

        protected override void Prepare(TextWriter writer)
        {
            base.Prepare(writer);

            // Make sure we're in a row, but only if we're also in a table
            if (GetComponent<Table>() != null && GetComponent<Row>() == null)
            {
                // ...and make sure the row is in a head section
                if (GetComponent<Section>() == null)
                {
                    new Head(Helper).Start(writer, true);
                }
                new Row(Helper).Start(writer, true);
            }
        }
    }
}