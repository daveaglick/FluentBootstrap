using System.IO;

namespace FluentBootstrap.Tables
{
    public abstract class TableSection : Tag,
        ICanCreate<TableRow>
    {
        protected TableSection(BootstrapHelper helper, string tagName, params string[] cssClasses)
            : base(helper, tagName, cssClasses)
        {
        }
        
        protected override void OnStart(TextWriter writer)
        {
            // Exit any existing table sections
            Pop<TableSection>(writer);

            base.OnStart(writer);
        }
    }
}