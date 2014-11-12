using System.IO;

namespace FluentBootstrap.Tables
{
    public interface ITableSectionCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class TableSectionWrapper<THelper> : TagWrapper<THelper>,
        ITableRowCreator<THelper>
    {
    }

    internal interface ITableSection : ITag
    {
    }

    public abstract class TableSection<THelper, TThis, TWrapper> : Tag<THelper, TThis, TWrapper>, ITableSection
        where TThis : TableSection<THelper, TThis, TWrapper>
        where TWrapper : TableSectionWrapper<THelper>, new()
    {
        protected TableSection(IComponentCreator<THelper> creator, string tagName, params string[] cssClasses)
            : base(creator, tagName, cssClasses)
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