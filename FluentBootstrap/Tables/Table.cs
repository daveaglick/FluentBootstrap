using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentBootstrap.Tables
{
    public class Table : Tag
    {
        internal bool Responsive { get; set; }

        public Table(BootstrapHelper helper) : base(helper, "table", "table")
        {
        }

        protected override void Prepare(TextWriter writer)
        {
            if (Responsive)
            {
                (new Tag(Helper, "div", "table-responsive")).Start(writer);
            }
        }
    }

    public abstract class TableSection : Tag
    {
        public TableSection(BootstrapHelper helper, string tagName, params string[] cssClasses) : base(helper, tagName, cssClasses)
        {
        }
    }

    public class TableHead : TableSection
    {
        public TableHead(BootstrapHelper helper) : base(helper, "thead")
        {
        }
    }

    public class TableBody : TableSection
    {
        public TableBody(BootstrapHelper helper) : base(helper, "tbody")
        {
        }
    }

    public class TableFoot : TableSection
    {
        public TableFoot(BootstrapHelper helper) : base(helper, "tfoot")
        {
        }
    }

    public class TableRow : Tag
    {
        public TableRow(BootstrapHelper helper) : base(helper, "tr")
        {
        }
    }

    public class TableData : Tag
    {
        public TableData(BootstrapHelper helper) : base(helper, "td")
        {
        }
    }

    public class TableHeading : Tag
    {
        public TableHeading(BootstrapHelper helper) : base(helper, "th")
        {
        }
    }
}
