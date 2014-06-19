namespace FluentBootstrap.Tables
{
    public interface ITableBody : ITableSection
    {
    }

    public class TableBody<TModel> : TableSection<TModel, TableBody<TModel>>, ITableBody
    {
        internal TableBody(BootstrapHelper<TModel> helper)
            : base(helper, "tbody")
        {
        }
    }
}