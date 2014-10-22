using System.IO;

namespace FluentBootstrap.Tables
{
    public interface ITableSectionCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class TableSectionWrapper<TModel> : TagWrapper<TModel>,
        ITableRowCreator<TModel>
    {
    }

    internal interface ITableSection : ITag
    {
    }

    public abstract class TableSection<TModel, TThis, TWrapper> : Tag<TModel, TThis, TWrapper>, ITableSection
        where TThis : TableSection<TModel, TThis, TWrapper>
        where TWrapper : TableSectionWrapper<TModel>, new()
    {
        protected TableSection(IComponentCreator<TModel> creator, string tagName, params string[] cssClasses)
            : base(creator, tagName, cssClasses)
        {
        }

        protected override void OnPrepare(TextWriter writer)
        {
            base.OnPrepare(writer);
            Pop<ITableSection>(writer);
        }
    }
}