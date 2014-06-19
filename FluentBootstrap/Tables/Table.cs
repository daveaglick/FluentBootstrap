using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentBootstrap.Tables
{
    public interface ITable : ITag
    {
    }

    public interface ITableCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class Table<TModel> : Tag<TModel, Table<TModel>>, ITable,
        ITableSectionCreator<TModel>,
        ITableRowCreator<TModel>,
        ITableCellCreator<TModel>
    {
        internal bool Responsive { get; set; }

        internal Table(BootstrapHelper<TModel> helper)
            : base(helper, "table", "table")
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
    }
}
