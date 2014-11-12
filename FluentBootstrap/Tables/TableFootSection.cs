namespace FluentBootstrap.Tables
{
    public interface ITableFootSectionCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class TableFootSectionWrapper<THelper> : TableSectionWrapper<THelper>
    {
    }

    internal interface ITableFootSection : ITableSection
    {
    }

    public class TableFootSection<THelper> : TableSection<THelper, TableFootSection<THelper>, TableFootSectionWrapper<THelper>>, ITableFootSection
    {
        internal TableFootSection(IComponentCreator<THelper> creator)
            : base(creator, "tfoot")
        {
        }
    }
}