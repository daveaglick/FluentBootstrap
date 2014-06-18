namespace FluentBootstrap.Tables
{
    public class TableBody : TableSection,
        TableRow.ICreate
    {
        internal TableBody(BootstrapHelper helper) : base(helper, "tbody")
        {
        }
    }
}