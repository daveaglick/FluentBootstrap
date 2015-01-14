using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tables
{
    public interface ITableCellCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class TableCellWrapper<TConfig> : TagWrapper<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface ITableCell : ITag
    {
    }

    public abstract class TableCell<TConfig, TThis, TWrapper> : Tag<TConfig, TThis, TWrapper>, ITableCell, IHasTableStateExtensions
        where TConfig : BootstrapConfig
        where TThis : TableCell<TConfig, TThis, TWrapper>
        where TWrapper : TableCellWrapper<TConfig>, new()
    {
        internal TableCell(BootstrapHelper helper, string tagName, params string[] cssClasses)
            : base(helper, tagName, cssClasses)
        {
        }
    }
}
