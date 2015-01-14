using System.IO;

namespace FluentBootstrap.Tables
{
    public interface ITableRowCreator<TConfig> : IComponentCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    public class TableRowWrapper<TConfig> : TagWrapper<TConfig>,
        ITableCellCreator<TConfig>
        where TConfig : BootstrapConfig
    {
    }

    internal interface ITableRow : ITag
    {
    }

    public class TableRow<TConfig> : Tag<TConfig, TableRow<TConfig>, TableRowWrapper<TConfig>>, ITableRow, IHasTableStateExtensions
        where TConfig : BootstrapConfig
    {
        internal bool HeadRow { get; set; }

        internal TableRow(BootstrapHelper helper)
            : base(helper, "tr")
        {
        }
        
        protected override void OnStart(TextWriter writer)
        {
            Pop<ITableRow>(writer);

            // Make sure we're in a section, but only if we're also in a table
            if (GetComponent<ITable>() != null)
            {
                ITableSection tableSection = GetComponent<ITableSection>();
                if (HeadRow)
                {
                    if (tableSection != null && !(tableSection is ITableHeadSection) && tableSection.Implicit)
                    {
                        Pop(tableSection, writer);
                        tableSection = null;
                    }
                    if (tableSection == null)
                    {
                        new TableHeadSection<TConfig>(Helper).Start(writer);
                    }
                }
                else
                {
                    if (tableSection != null && !(tableSection is ITableBodySection) && tableSection.Implicit)
                    {
                        Pop(tableSection, writer);
                        tableSection = null;
                    }
                    if (tableSection == null)
                    {
                        new TableBodySection<TConfig>(Helper).Start(writer);
                    }
                }
            }

            base.OnStart(writer);
        }
    }
}