namespace FluentBootstrap.Tables
{
    public class TableBody<TModel> : TableSection<TModel>,
        TableRow<TModel>.ICreate
    {
        internal TableBody(BootstrapHelper<TModel> helper)
            : base(helper, "tbody")
        {
        }
    }
}