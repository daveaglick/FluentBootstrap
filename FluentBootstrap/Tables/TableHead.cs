namespace FluentBootstrap.Tables
{
    public class TableHead<TModel> : TableSection<TModel>,
        TableRow<TModel>.ICreate
    {
        internal TableHead(BootstrapHelper<TModel> helper)
            : base(helper, "thead")
        {
        }
    }
}