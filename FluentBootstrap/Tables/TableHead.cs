namespace FluentBootstrap.Tables
{
    public class TableHead : TableSection,
        TableRow.ICreate
    {
        public interface ICreate : ICreateComponent
        {
        }

        internal TableHead(BootstrapHelper helper) : base(helper, "thead")
        {
        }
    }
}