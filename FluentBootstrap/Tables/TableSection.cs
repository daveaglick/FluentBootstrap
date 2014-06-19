using System.IO;

namespace FluentBootstrap.Tables
{
    public interface ITableSection : ITag
    {
    }

    public interface ITableSectionCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public abstract class TableSection<TModel, TThis> : Tag<TModel, TThis>, ITableSection,
        ITableRowCreator<TModel>
        where TThis : TableSection<TModel, TThis>
    {
        protected TableSection(BootstrapHelper<TModel> helper, string tagName, params string[] cssClasses)
            : base(helper, tagName, cssClasses)
        {
        }

        protected override void Prepare(TextWriter writer)
        {
            base.Prepare(writer);
            Pop<ITableSection>(writer);
        }
    }
}