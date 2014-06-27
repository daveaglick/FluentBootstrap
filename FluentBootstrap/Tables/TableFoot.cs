namespace FluentBootstrap.Tables
{
    internal interface ITableFoot : ITableSection
    {
    }

    public class TableFoot<TModel> : TableSection<TModel, TableFoot<TModel>>, ITableFoot
    {
        internal TableFoot(BootstrapHelper<TModel> helper)
            : base(helper, "tfoot")
        {
        }
    }
}