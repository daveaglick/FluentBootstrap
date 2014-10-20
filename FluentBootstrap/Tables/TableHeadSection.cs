namespace FluentBootstrap.Tables
{
    public interface ITableHeadSectionCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class TableHeadSectionWrapper<TModel> : TableSectionWrapper<TModel>
    {
    }

    internal interface ITableHeadSection : ITableSection
    {
    }

    public class TableHeadSection<TModel> : TableSection<TModel, TableHeadSection<TModel>, TableHeadSectionWrapper<TModel>>, ITableHeadSection
    {
        internal TableHeadSection(IComponentCreator<TModel> creator)
            : base(creator, "thead")
        {
        }
    }
}