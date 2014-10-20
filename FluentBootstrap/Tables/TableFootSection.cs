namespace FluentBootstrap.Tables
{
    public interface ITableFootSectionCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class TableFootSectionWrapper<TModel> : TableSectionWrapper<TModel>
    {
    }

    internal interface ITableFootSection : ITableSection
    {
    }

    public class TableFootSection<TModel> : TableSection<TModel, TableFootSection<TModel>, TableFootSectionWrapper<TModel>>, ITableFootSection
    {
        internal TableFootSection(IComponentCreator<TModel> creator)
            : base(creator, "tfoot")
        {
        }
    }
}