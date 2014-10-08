namespace FluentBootstrap.Tables
{
    internal interface ITableBody : ITableSection
    {
    }

    public class TableBodySection<TModel> : TableSection<TModel, TableBodySection<TModel>>, ITableBody
    {
        internal TableBodySection(BootstrapHelper<TModel> helper)
            : base(helper, "tbody")
        {
        }
    }
}