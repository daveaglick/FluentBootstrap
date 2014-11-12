using System.IO;

namespace FluentBootstrap.Tables
{
    public interface ITableRowCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class TableRowWrapper<THelper> : TagWrapper<THelper>,
        ITableCellCreator<THelper>
    {
    }

    internal interface ITableRow : ITag
    {
    }

    public class TableRow<THelper> : Tag<THelper, TableRow<THelper>, TableRowWrapper<THelper>>, ITableRow, IHasTableStateExtensions
    {
        internal bool HeadRow { get; set; }

        internal TableRow(IComponentCreator<THelper> creator)
            : base(creator, "tr")
        {
        }
        
        protected override void OnStart(TextWriter writer)
        {
            Pop<ITableRow>(writer);

            // Make sure we're in a section, but only if we're also in a table
            if (GetComponent<ITable>() != null && GetComponent<ITableSection>() == null)
            {
                if (HeadRow)
                {
                    new TableHeadSection<THelper>(Helper).Start(writer);
                }
                else
                {
                    new TableBodySection<THelper>(Helper).Start(writer);
                }
            }

            base.OnStart(writer);
        }
    }
}