namespace FluentBootstrap.Tables
{
    public class TableHead : TableSection,
        TableRow.ICreate
    {
        internal TableHead(BootstrapHelper helper) : base(helper, "thead")
        {
        }
        
        public interface ICreate : ICreateComponent
        {
        }
    }
}