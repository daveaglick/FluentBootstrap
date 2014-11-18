namespace FluentBootstrap.Tables
{
    public interface ITableFootSectionCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class TableFootSectionWrapper<THelper> : TableSectionWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface ITableFootSection : ITableSection
    {
    }

    public class TableFootSection<THelper> : TableSection<THelper, TableFootSection<THelper>, TableFootSectionWrapper<THelper>>, ITableFootSection
        where THelper : BootstrapHelper<THelper>
    {
        internal TableFootSection(IComponentCreator<THelper> creator)
            : base(creator, "tfoot")
        {
        }
    }
}