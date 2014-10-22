using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tables
{
    public interface ITableCellCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class TableCellWrapper<TModel> : TagWrapper<TModel>
    {
    }

    internal interface ITableCell : ITag
    {
    }

    public abstract class TableCell<TModel, TThis, TWrapper> : Tag<TModel, TThis, TWrapper>, ITableCell, IHasTableStateExtensions
        where TThis : TableCell<TModel, TThis, TWrapper>
        where TWrapper : TableCellWrapper<TModel>, new()
    {
        internal TableCell(IComponentCreator<TModel> creator, string tagName, params string[] cssClasses)
            : base(creator, tagName, cssClasses)
        {
        }
    }
}
