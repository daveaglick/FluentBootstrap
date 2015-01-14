namespace FluentBootstrap.Tables
{
    public interface ITableFootSectionCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class TableFootSectionWrapper<TConfig> : TableSectionWrapper<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface ITableFootSection : ITableSection
    {
    }

    public class TableFootSection<TConfig> : TableSection<TConfig, TableFootSection<TConfig>, TableFootSectionWrapper<TConfig>>, ITableFootSection
        where TConfig : BootstrapConfig
    {
        internal TableFootSection(BootstrapHelper helper)
            : base(helper, "tfoot")
        {
        }
    }
}