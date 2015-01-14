namespace FluentBootstrap.Tables
{
    public interface ITableHeadSectionCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class TableHeadSectionWrapper<TConfig> : TableSectionWrapper<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface ITableHeadSection : ITableSection
    {
    }

    public class TableHeadSection<TConfig> : TableSection<TConfig, TableHeadSection<TConfig>, TableHeadSectionWrapper<TConfig>>, ITableHeadSection
        where TConfig : BootstrapConfig
    {
        internal TableHeadSection(BootstrapHelper helper)
            : base(helper, "thead")
        {
        }
    }
}