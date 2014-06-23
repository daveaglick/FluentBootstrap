using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tables
{
    public interface ITableCell : ITag
    {
    }

    public interface ITableCellCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public abstract class TableCell<TModel, TThis> : Tag<TModel, TThis>, ITableCell, IHasTableContextExtensions
        where TThis : TableCell<TModel, TThis>
    {
        internal TableCell(BootstrapHelper<TModel> helper, string tagName, params string[] cssClasses)
            : base(helper, tagName, cssClasses)
        {
        }

        protected override void PreStart(TextWriter writer)
        {
            Pop<ITableCell>(writer);
            base.PreStart(writer);
        }
    }
}
