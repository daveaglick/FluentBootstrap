namespace FluentBootstrap.Tables
{
    public class TableBody : TableSection,
        TableRow.ICreate
    {
        public interface ICreate : ICreateComponent
        {
        }

        internal TableBody(BootstrapHelper helper) : base(helper, "tbody")
        {
        }
    }
}