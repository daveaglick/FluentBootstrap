namespace FluentBootstrap.Tables
{
    public class TableBody : TableSection,
        TableRow.ICreate
    {
        internal TableBody(BootstrapHelper helper) : base(helper, "tbody")
        {
        }

        public interface ICreate : ICreateComponent
        {
        }
    }
}