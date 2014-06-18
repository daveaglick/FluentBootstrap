using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentBootstrap.Tables
{
    public class Table : Tag,
        TableSection.ICreate,
        TableRow.ICreate,
        TableCell.ICreate
    {
        internal bool Responsive { get; set; }

        internal Table(BootstrapHelper helper) : base(helper, "table", "table")
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            if (Responsive)
            {
                TagBuilder tag = new TagBuilder("div");
                tag.AddCssClass("table-responsive");
                writer.Write(tag.ToString(TagRenderMode.StartTag));
            }
            base.OnStart(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            base.OnFinish(writer);
            if (Responsive)
            {
                TagBuilder tag = new TagBuilder("div");
                writer.Write(tag.ToString(TagRenderMode.EndTag));
            }
        }

        public interface ICreate : ICreateComponent
        {
        }
    }
}
