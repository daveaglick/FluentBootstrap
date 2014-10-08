namespace FluentBootstrap.Tables
{
    internal interface ITableHead : ITableSection
    {
    }

    public class TableHeadSection<TModel> : TableSection<TModel, TableHeadSection<TModel>>, ITableHead
    {
        internal TableHeadSection(BootstrapHelper<TModel> helper)
            : base(helper, "thead")
        {
        }
    }
}