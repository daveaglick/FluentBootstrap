namespace FluentBootstrap.Tables
{
    public interface ITableBodySectionCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class TableBodySectionWrapper<TModel> : TableSectionWrapper<TModel>
    {
    }

    internal interface ITableBodySection : ITableSection
    {
    }

    public class TableBodySection<TModel> : TableSection<TModel, TableBodySection<TModel>, TableBodySectionWrapper<TModel>>, ITableBodySection
    {
        internal TableBodySection(IComponentCreator<TModel> creator)
            : base(creator, "tbody")
        {
        }
    }
}