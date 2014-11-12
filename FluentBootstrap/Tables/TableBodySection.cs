namespace FluentBootstrap.Tables
{
    public interface ITableBodySectionCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class TableBodySectionWrapper<THelper> : TableSectionWrapper<THelper>
    {
    }

    internal interface ITableBodySection : ITableSection
    {
    }

    public class TableBodySection<THelper> : TableSection<THelper, TableBodySection<THelper>, TableBodySectionWrapper<THelper>>, ITableBodySection
    {
        internal TableBodySection(IComponentCreator<THelper> creator)
            : base(creator, "tbody")
        {
        }
    }
}