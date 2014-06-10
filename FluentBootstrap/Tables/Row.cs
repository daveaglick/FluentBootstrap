using System.IO;

namespace FluentBootstrap.Tables
{
    public class Row : Tag, ITableContext
    {
        internal Row(BootstrapHelper helper) : base(helper, "tr")
        {
        }

        protected override void Prepare(TextWriter writer)
        {
            base.Prepare(writer);

            Pop<Row>(writer);

            // Make sure we're in a section, but only if we're also in a table
            if (GetComponent<Table>() != null && GetComponent<Section>() == null)
            {
                new Body(Helper).Start(writer, true);
            }
        }
    }
}