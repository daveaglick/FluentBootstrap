namespace FluentBootstrap.Tables
{
    public interface ITableBodySectionCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class TableBodySectionWrapper<TConfig> : TableSectionWrapper<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface ITableBodySection : ITableSection
    {
    }

    public class TableBodySection<TConfig> : TableSection<TConfig, TableBodySection<TConfig>, TableBodySectionWrapper<TConfig>>, ITableBodySection
        where TConfig : BootstrapConfig
    {
        internal TableBodySection(BootstrapHelper helper)
            : base(helper, "tbody")
        {
        }
    }
}