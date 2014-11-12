namespace FluentBootstrap.Tables
{
    public interface ITableHeadSectionCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class TableHeadSectionWrapper<THelper> : TableSectionWrapper<THelper>
    {
    }

    internal interface ITableHeadSection : ITableSection
    {
    }

    public class TableHeadSection<THelper> : TableSection<THelper, TableHeadSection<THelper>, TableHeadSectionWrapper<THelper>>, ITableHeadSection
    {
        internal TableHeadSection(IComponentCreator<THelper> creator)
            : base(creator, "thead")
        {
        }
    }
}