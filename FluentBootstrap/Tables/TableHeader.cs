using System.IO;

namespace FluentBootstrap.Tables
{
    public interface ITableHeaderCreator<TModel> : IComponentCreator<TModel>
    {
    }

    public class TableHeaderWrapper<TModel> : TableCellWrapper<TModel>
    {
    }

    internal interface ITableHeader : ITableCell
    {
    }

    public class TableHeader<TModel> : TableCell<TModel, TableHeader<TModel>, TableHeaderWrapper<TModel>>, ITableHeader
    {
        internal TableHeader(IComponentCreator<TModel> creator)
            : base(creator, "th")
        {
        }

        protected override void OnPrepare(TextWriter writer)
        {
            base.OnPrepare(writer);

            // Make sure we're in a row, but only if we're also in a table
            if (GetComponent<ITable>() != null && GetComponent<ITableRow>() == null)
            {
                // ...and make sure the row is in a head section
                if (GetComponent<ITableSection>() == null)
                {
                    new TableHeadSection<TModel>(Helper).Start(writer);
                }
                new TableRow<TModel>(Helper).Start(writer);
            }
        }
    }
}