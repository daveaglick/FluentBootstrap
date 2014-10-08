namespace FluentBootstrap.Tables
{
    internal interface ITableFoot : ITableSection
    {
    }

    public class TableFootSection<TModel> : TableSection<TModel, TableFootSection<TModel>>, ITableFoot
    {
        internal TableFootSection(BootstrapHelper<TModel> helper)
            : base(helper, "tfoot")
        {
        }
    }
}