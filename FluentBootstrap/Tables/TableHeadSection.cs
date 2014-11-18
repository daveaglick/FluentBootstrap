namespace FluentBootstrap.Tables
{
    public interface ITableHeadSectionCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class TableHeadSectionWrapper<THelper> : TableSectionWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface ITableHeadSection : ITableSection
    {
    }

    public class TableHeadSection<THelper> : TableSection<THelper, TableHeadSection<THelper>, TableHeadSectionWrapper<THelper>>, ITableHeadSection
        where THelper : BootstrapHelper<THelper>
    {
        internal TableHeadSection(IComponentCreator<THelper> creator)
            : base(creator, "thead")
        {
        }
    }
}