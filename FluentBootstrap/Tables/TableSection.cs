using System.IO;

namespace FluentBootstrap.Tables
{
    public abstract class TableSection : Tag
    {
        protected TableSection(BootstrapHelper helper, string tagName, params string[] cssClasses) : base(helper, tagName, cssClasses)
        {
        }

        protected override void Prepare(TextWriter writer)
        {
            base.Prepare(writer);
            Pop<TableSection>(writer);
        }

        public interface ICreate : ICreateComponent
        {
        }
    }
}