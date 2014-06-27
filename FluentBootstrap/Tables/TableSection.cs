using System.IO;

namespace FluentBootstrap.Tables
{
    internal interface ITableSection : ITag
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

        protected override void PreStart(TextWriter writer)
        {
            base.PreStart(writer);
            Pop<ITableSection>(writer);
        }
    }
}