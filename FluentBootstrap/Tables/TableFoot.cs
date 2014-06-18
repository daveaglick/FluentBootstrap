namespace FluentBootstrap.Tables
{
    public class TableFoot<TModel> : TableSection<TModel>,
        TableRow<TModel>.ICreate
    {
        internal TableFoot(BootstrapHelper<TModel> helper)
            : base(helper, "tfoot")
        {
        }
    }
}