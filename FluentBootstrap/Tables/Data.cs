using System.IO;

namespace FluentBootstrap.Tables
{
    public class Data : Cell
    {
        internal Data(BootstrapHelper helper) : base(helper, "td")
        {
        }

        protected override void Prepare(TextWriter writer)
        {
            base.Prepare(writer);

            // Only add implicit components if we're in a table
            if (GetComponent<Table>() != null)
            {
                // If we're in a head section, exit out
                Pop<Head>(writer);

                // Make sure we're in a row
                if (GetComponent<Row>() == null)
                {
                    new Row(Helper).Start(writer, true);
                }
            }
        }
    }
}