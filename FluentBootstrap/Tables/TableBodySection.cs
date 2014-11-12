namespace FluentBootstrap.Tables
{
    public interface ITableBodySectionCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class TableBodySectionWrapper<THelper> : TableSectionWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface ITableBodySection : ITableSection
    {
    }

    public class TableBodySection<THelper> : TableSection<THelper, TableBodySection<THelper>, TableBodySectionWrapper<THelper>>, ITableBodySection
        where THelper : BootstrapHelper<THelper>
    {
        internal TableBodySection(IComponentCreator<THelper> creator)
            : base(creator, "tbody")
        {
        }
    }
}