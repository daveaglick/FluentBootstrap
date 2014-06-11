namespace FluentBootstrap.Tables
{
    public class TableFoot : TableSection,
        TableRow.ICreate
    {
        public interface ICreate : ICreateComponent
        {
        }

        internal TableFoot(BootstrapHelper helper) : base(helper, "tfoot")
        {
        }
    }
}