using System.IO;

namespace FluentBootstrap.Tables
{
    public abstract class Section : Tag
    {
        protected Section(BootstrapHelper helper, string tagName, params string[] cssClasses) : base(helper, tagName, cssClasses)
        {
        }

        protected override void Prepare(TextWriter writer)
        {
            base.Prepare(writer);
            Pop<Section>(writer);
        }
    }
}