using System.IO;

namespace FluentBootstrap.Tables
{
    public interface ITableSectionCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class TableSectionWrapper<TConfig> : TagWrapper<TConfig>,
        ITableRowCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface ITableSection : ITag
    {
    }

    public abstract class TableSection<TConfig, TThis, TWrapper> : Tag<TConfig, TThis, TWrapper>, ITableSection
        where TConfig : BootstrapConfig
        where TThis : TableSection<TConfig, TThis, TWrapper>
        where TWrapper : TableSectionWrapper<TConfig>, new()
    {
        protected TableSection(BootstrapHelper helper, string tagName, params string[] cssClasses)
            : base(helper, tagName, cssClasses)
        {
        }
        
        protected override void OnStart(TextWriter writer)
        {
            // Exit any existing table sections
            Pop<ITableSection>(writer);

            base.OnStart(writer);
        }
    }
}