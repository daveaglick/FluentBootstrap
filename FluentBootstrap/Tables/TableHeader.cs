using System.IO;

namespace FluentBootstrap.Tables
{
    public interface ITableHeaderCreator<THelper> : IComponentCreator<THelper>
    {
    }

    public class TableHeaderWrapper<THelper> : TableCellWrapper<THelper>
    {
    }

    internal interface ITableHeader : ITableCell
    {
    }

    public class TableHeader<THelper> : TableCell<THelper, TableHeader<THelper>, TableHeaderWrapper<THelper>>, ITableHeader
    {
        internal TableHeader(IComponentCreator<THelper> creator)
            : base(creator, "th")
        {
        }
        
        protected override void OnStart(TextWriter writer)
        {
            // Make sure we're in a row, but only if we're also in a table
            if (GetComponent<ITable>() != null && GetComponent<ITableRow>() == null)
            {
                // ...and make sure the row is in a head section
                if (GetComponent<ITableSection>() == null)
                {
                    new TableHeadSection<THelper>(Helper).Start(writer);
                }
                new TableRow<THelper>(Helper).Start(writer);
            }

            base.OnStart(writer);
        }
    }
}