using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FluentBootstrap.Tables
{
    internal interface ITable : ITag
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
            : base(helper, "table", Css.Table)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            if (Responsive)
            {
                TagBuilder tag = new TagBuilder("div");
                tag.AddCssClass(Css.TableResponsive);
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
