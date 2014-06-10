using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tables
{
    public abstract class Cell : Tag, ITableContext
    {
        internal Cell(BootstrapHelper helper, string tagName, params string[] cssClasses) : base(helper, tagName, cssClasses)
        {
        }

        protected override void Prepare(TextWriter writer)
        {
            Pop<Cell>(writer);
            base.Prepare(writer);
        }
    }
}
