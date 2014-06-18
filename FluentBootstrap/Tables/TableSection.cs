using System.IO;

namespace FluentBootstrap.Tables
{
    public abstract class TableSection<TModel> : Tag<TModel>
    {
        protected TableSection(BootstrapHelper<TModel> helper, string tagName, params string[] cssClasses)
            : base(helper, tagName, cssClasses)
        {
        }

        protected override void Prepare(TextWriter writer)
        {
            base.Prepare(writer);
            Pop<TableSection<TModel>>(writer);
        }

        public interface ICreate : ICreateComponent<TModel>
        {
        }
    }
}