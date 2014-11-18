using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tables
{
    public interface ITableCellCreator<THelper> : IComponentCreator<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    public class TableCellWrapper<THelper> : TagWrapper<THelper>
        where THelper : BootstrapHelper<THelper>
    {
    }

    internal interface ITableCell : ITag
    {
    }

    public abstract class TableCell<THelper, TThis, TWrapper> : Tag<THelper, TThis, TWrapper>, ITableCell, IHasTableStateExtensions
        where THelper : BootstrapHelper<THelper>
        where TThis : TableCell<THelper, TThis, TWrapper>
        where TWrapper : TableCellWrapper<THelper>, new()
    {
        internal TableCell(IComponentCreator<THelper> creator, string tagName, params string[] cssClasses)
            : base(creator, tagName, cssClasses)
        {
        }
    }
}
