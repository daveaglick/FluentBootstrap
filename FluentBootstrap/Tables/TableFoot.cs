namespace FluentBootstrap.Tables
{
    public class TableFoot : TableSection,
        TableRow.ICreate
    {
        internal TableFoot(BootstrapHelper helper) : base(helper, "tfoot")
        {
        }
    }
}