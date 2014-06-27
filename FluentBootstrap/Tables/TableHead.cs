namespace FluentBootstrap.Tables
{
    internal interface ITableHead : ITableSection
    {
    }

    public class TableHead<TModel> : TableSection<TModel, TableHead<TModel>>, ITableHead
    {
        internal TableHead(BootstrapHelper<TModel> helper)
            : base(helper, "thead")
        {
        }
    }
}